import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { ToastrService } from 'ngx-toastr';
import { Customer } from 'src/app/models/customer';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  currentCustomer: Customer;

  constructor(private _authenticationService: AuthenticationService, 
    private toastrService: ToastrService, 
    private _router: Router) {
      this._authenticationService.currentCustomer.subscribe(x => this.currentCustomer = x);
     }

  ngOnInit() {
  }

  logout() {
    this._authenticationService.logout();
    this._router.navigate(['/login']);
  }

}
