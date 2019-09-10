import { Component, OnInit } from '@angular/core';
import { Field } from 'src/app/models/field';
import { FieldService } from 'src/app/services/field.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-homepage',
  templateUrl: './homepage.component.html',
  styleUrls: ['./homepage.component.css']
})
export class HomepageComponent implements OnInit {

  fields: Field[] = [];

  constructor(private _fieldService: FieldService, private router: Router) { }

  ngOnInit() {
    this.getFields();
  }

  getFields() {
    this._fieldService.getFields().subscribe(
      (fields: Field[]) => {
        this.fields = fields;
      })
  }

  redirectToAngularCalendar(field: Field) {
    localStorage.setItem('field', JSON.stringify(field));
    this.router.navigateByUrl('/field/' + field.pathURL);
  }

}
