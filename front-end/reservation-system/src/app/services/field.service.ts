import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { AppConfig } from '../app-config';
import { Field } from '../models/field';

@Injectable({
  providedIn: 'root'
})
export class FieldService {

  constructor(private _http: HttpClient, private appConfig: AppConfig) { }

  getFields() {
    return this._http.get<Field[]>(this.appConfig.apiUrl + '/api/field/GetFields');
  }
}
