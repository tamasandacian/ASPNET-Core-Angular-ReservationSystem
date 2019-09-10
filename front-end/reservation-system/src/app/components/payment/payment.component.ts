import { Component, OnInit, ChangeDetectorRef, ViewChild, ElementRef } from '@angular/core';
import { Reservation } from 'src/app/models/reservation';
import { CalendarService } from 'src/app/services/calendar.service';
import { ToastrService } from 'ngx-toastr';
import { Field } from 'src/app/models/field';
import { Customer } from 'src/app/models/customer';
import { ActivatedRoute, Router } from '@angular/router';

declare var paypal;

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {
  @ViewChild('paypal', { static: true }) paypalElement: ElementRef;

  reservation: Reservation;
  field: Field;
  customer: Customer;

  constructor(private calendarService: CalendarService, private toastrService: ToastrService, private router: Router) {
    this.reservation = JSON.parse(localStorage.getItem('reservation'));
    this.field = JSON.parse(localStorage.getItem('field'));
  }

  ngOnInit() {
    paypal
      .Buttons({
        createOrder: (data, actions) => {
          return actions.order.create({
            purchase_units: [
              {
                description: "Field: " + this.field.title,
                amount: {
                  currency_code: 'DKK',
                  value: this.reservation.total
                }
              }
            ]
          });
        },
        onApprove: async (data, actions) => {
          const order = await actions.order.capture();
          this.calendarService.createReservation(this.reservation).subscribe(
            () => {
              this.toastrService.success("Payment successfully done!");
              this.router.navigate(['/field/' + this.field.pathURL]);
            },
            (error) => {
              this.toastrService.error("Some error occured while processing the transaction!");
            })

        },
        onError: err => {
          this.toastrService.error(err);
        }
      })
      .render(this.paypalElement.nativeElement);
  }
}

