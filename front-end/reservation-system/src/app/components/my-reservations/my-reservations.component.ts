import { Component, OnInit } from '@angular/core';
import { CustomerService } from 'src/app/services/customer.service';
import { Customer } from 'src/app/models/customer';
import { Router } from '@angular/router';

@Component({
  selector: 'app-my-reservations',
  templateUrl: './my-reservations.component.html',
  styleUrls: ['./my-reservations.component.css']
})
export class MyReservationsComponent implements OnInit {

  customer: Customer;
  reservations: any[] = [];

  constructor(private _customerService: CustomerService, private router: Router) {
    this.customer = JSON.parse(localStorage.getItem('customer'))
   }

  ngOnInit() {
    this.getMyReservations();
  }

  getMyReservations() {
    this._customerService.getCustomerReservations(this.customer.customerId).subscribe(
      (reservations) => {
        this.reservations = reservations;
      }
    )
  }

  redirectToCalendar(reservation: any) {
    let data = {
      id: reservation.id,
      startProgram: reservation.startProgram,
      endProgram: reservation.endProgram,
      start: reservation.start,
      end: reservation.end
    };

    console.log("redirect to calendar: " + JSON.stringify(reservation));
    localStorage.setItem('attr', JSON.stringify(data))
    this.router.navigate(['/my-reservations/field/' + reservation.path + "/reservation/" + reservation.id]);
  }

}
