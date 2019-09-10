import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConfig } from '../app-config';
import { map } from 'rxjs/operators';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  private currentCustomerSubject: BehaviorSubject<any>;
  public currentCustomer: Observable<any>;

  constructor(private _http: HttpClient, private _appConfig: AppConfig) {
    this.currentCustomerSubject = new BehaviorSubject<any>(JSON.parse(localStorage.getItem('customer')));
    this.currentCustomer = this.currentCustomerSubject.asObservable();
  }

  public get currentCustomerValue() {
    return this.currentCustomerSubject.value;
  }

  login(emailAddress: string, password: string) {
    return this._http.post<any>(this._appConfig.apiUrl + '/api/customer/Authenticate', { emailAddress, password })
      .pipe(map(customer => {

        if (customer && customer.token) {
            // store customer details and jwt token in local storage to keep user logged in between page refreshes
            localStorage.setItem('customer', JSON.stringify(customer));
            this.currentCustomerSubject.next(customer);
        }
     
        return customer;
      }));
  }

  logout() {
    // remove user from local storage and set current customer to null
    localStorage.clear();
    localStorage.removeItem('reservation');
    localStorage.removeItem('attr');
    localStorage.removeItem('field');
    this.currentCustomerSubject.next(null);
  }
}
