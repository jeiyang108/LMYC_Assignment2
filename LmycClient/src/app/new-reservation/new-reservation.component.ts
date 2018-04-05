import { Component, OnInit } from '@angular/core';
import { Boat, BoatService } from '../boat.service';
import { ReservationsService, Reservation } from '../reservations.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-reservation',
  templateUrl: './new-reservation.component.html',
  styleUrls: ['./new-reservation.component.css']
})
export class NewReservationComponent implements OnInit {

  public boats: Boat[] = [];
  public startDateT: Date = new Date();
  public endDateT: Date = new Date();

  public selectedBoat: string = null;

  constructor(private boatService: BoatService, private reservationsService: ReservationsService, private router: Router) { }

  ngOnInit() {
    this.boatService.GetBoats().then(r => {
      this.boats = r;
    });
  }

  createReservation() {
    if (this.selectedBoat == null)
      return;

    let r: Reservation = new Reservation();

    r.startDate = this.startDateT.toISOString();
    r.endDate = this.endDateT.toISOString();
    r.reservedBoat = parseInt(this.selectedBoat);

    this.reservationsService.CreateReservation(r).then(r => {
      this.router.navigate(["/reservations/"]);
    })
  }

}
