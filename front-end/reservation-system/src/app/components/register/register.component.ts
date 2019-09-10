import { Component, OnInit } from '@angular/core';
import { CustomerService } from 'src/app/services/customer.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  
  model: any = {};


  constructor(private _customerService: CustomerService, private toastr: ToastrService, private router: Router) { }

  ngOnInit() {
  }

  register() {
    this._customerService.register(this.model).subscribe(
      (data) => {
        this.toastr.success('Customer registered successfully!');
        this.router.navigate(['login']);
      },
      (error) => {
        this.toastr.error(error.error);
      }
    )
  }

}
