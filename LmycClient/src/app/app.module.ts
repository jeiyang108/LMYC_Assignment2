import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http'
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { ReservationsComponent } from './reservations/reservations.component';
import { NewReservationComponent } from './new-reservation/new-reservation.component';
import { PageNotFoundComponent } from './PageNotFound/PageNotFound.component';
import { AccountService } from "./account.service";
import { BoatService } from "./boat.service";
import { ReservationsService } from "./reservations.service";
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material';

const appRoutes: Routes = [
  {
    path: 'reservations',
    component: ReservationsComponent
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'newReservation',
    component: NewReservationComponent
  },
  {
    path: '',
    redirectTo: '/login',
    pathMatch: 'full'
  },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    ReservationsComponent,
    NewReservationComponent,
    PageNotFoundComponent
  ],
  imports: [
    RouterModule.forRoot(appRoutes),
    BrowserModule,
    FormsModule,
    HttpModule,
    HttpClientModule,
    MatNativeDateModule,
    MatDatepickerModule
  ],
  providers: [AccountService, BoatService, ReservationsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
