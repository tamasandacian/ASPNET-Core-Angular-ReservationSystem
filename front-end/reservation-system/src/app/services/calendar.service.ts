import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppConfig } from '../app-config';
import { Observable } from 'rxjs';
import { Reservation } from '../models/reservation';
import { map, distinctUntilChanged, debounceTime, switchMap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CalendarService {

  constructor(private _http: HttpClient, private _appConfig: AppConfig) { }

  getCalendarReservations(fieldId: number): Observable<any[]> {
    return this._http.get<any[]>(this._appConfig.apiUrl + '/api/calendar/GetReservations/' + fieldId);
  }

  createReservation(reservation: Reservation) {
    return this._http.post(this._appConfig.apiUrl + '/api/calendar/CreateReservation', reservation);
  }

  getReservationById(id: number) {
    return this._http.get(this._appConfig.apiUrl + '/api/calendar/GetReservationById/' + id);
  }

  search(terms: Observable<string>, fieldId: number) {
    return terms.pipe(
      debounceTime(500),
      distinctUntilChanged(),
      switchMap(
        term => this.searchEntries(term, fieldId)
      )
    );
  }

  searchEntries(term, fieldId) {
    if (term !== '') {
      return this._http.get(this._appConfig.apiUrl + '/api/calendar/SearchReservations/' + term);
    } else {
      return [];
    }
  }

}
