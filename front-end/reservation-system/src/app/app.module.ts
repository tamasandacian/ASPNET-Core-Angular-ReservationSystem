
// ANGULAR LIBRARIES
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms'; 
import { AppRoutingModule } from './app-routing.module';

// COMPONENTS //
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { CarouselComponent } from './components/carousel/carousel.component';

import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';

import { HomepageComponent } from './components/homepage/homepage.component';
import { CalendarComponent } from './components/calendar/calendar.component';
import { PaymentComponent } from './components/payment/payment.component';
import { ReservationDetailComponent } from './components/reservation-detail/reservation-detail.component';
import { MyReservationsComponent } from './components/my-reservations/my-reservations.component';

// CONFIG CLASSES//
import { AppConfig } from './app-config';
import { CalendarConfig } from './calendar-config';

// NG BOOTSTRAP
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';

// ANGULAR BOOTSTRAP CALENDAR 6+ //
import { CalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import { FlatpickrModule } from 'angularx-flatpickr';
import 'flatpickr/dist/flatpickr.css'; 

// DATETIME PICKER NGUI
import { NguiDatetimePickerModule } from '@ngui/datetime-picker';

// NGX TOASTR NOTIFICATIONS
import { ToastrModule, ToastContainerModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    HomepageComponent,
    FooterComponent,
    HeaderComponent,
    RegisterComponent,
    LoginComponent,
    NavbarComponent,
    CarouselComponent,
    CalendarComponent,
    PaymentComponent,
    ReservationDetailComponent,
    MyReservationsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    CalendarModule.forRoot({
      provide: DateAdapter,
      useFactory: adapterFactory
    }),
    FlatpickrModule.forRoot(),
    NgbModule,
    FormsModule,
    HttpClientModule,
    NguiDatetimePickerModule,
    ToastrModule.forRoot({
      positionClass: 'toast-top-right',
      preventDuplicates: true,
      enableHtml: true
    }),
    ToastContainerModule
    
  ],
  providers: [AppConfig, CalendarConfig],
  bootstrap: [AppComponent]
})
export class AppModule { }
