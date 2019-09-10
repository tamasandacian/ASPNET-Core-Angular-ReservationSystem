import { Component, OnInit } from '@angular/core';
import { CalendarService } from 'src/app/services/calendar.service';
import { CalendarView } from 'angular-calendar';
import { CalendarConfig } from 'src/app/calendar-config';

@Component({
  selector: 'app-reservation-detail',
  templateUrl: './reservation-detail.component.html',
  styleUrls: ['./reservation-detail.component.css']
})
export class ReservationDetailComponent implements OnInit {

    // It maintains a list of calendar events
    public events: any[] = [];

    // Angular Bootstrap Calendar 6+
    view: CalendarView = CalendarView.Week;
    CalendarView = CalendarView;
    activeDayIsOpen: boolean = true;
    viewDate: Date = new Date();
    
    startProgram: any;
    endProgram: any;
    data: any;
  
    constructor(private calendarService: CalendarService, private calendarConfig: CalendarConfig) { 
      this.data = JSON.parse(localStorage.getItem('attr'))
      this.startProgram = this.data.startProgram;
      this.endProgram = this.data.endProgram;
    }
  
    ngOnInit() {
      this.getReservationById();
    }
  
    setView(view: CalendarView) {
      this.view = view;
    }
  
    closeOpenMonthViewDay() {
      this.activeDayIsOpen = false;
    }
  
    getReservationById() {
      this.calendarService.getReservationById(this.data.id).subscribe(
        (events: any) => {
          this.events = events;

          // Display default calendar date as start date from created reservation
          this.viewDate = new Date(this.data.start);
          this.events.forEach(event => {
            event.start = new Date(event.start),
            event.end = new Date(event.end),
            event.color = this.calendarConfig.colors.green
          });
  
        }
      )
    }

}
