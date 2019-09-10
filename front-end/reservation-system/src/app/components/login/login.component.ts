import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  model: any = {};

  constructor(private _authenticationService: AuthenticationService, private _toastrService: ToastrService, private _router: Router) { }

  ngOnInit() {
  }

  login() {
    this._authenticationService.login(this.model.emailAddress, this.model.password).subscribe(
      () => {
        this._toastrService.success("Successfully logged in!");
        this._router.navigate(['']);
      },
      (error) => {
        this._toastrService.error(error.error);
      }
    )
  }

}
