import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';
import { AccountService } from './account.service';


export class Boat {

  public boatId: number;
  public boatName: string;

}

@Injectable()
export class BoatService {

  private boatURL: string;

  constructor(private client: HttpClient, private accountService: AccountService) {
    this.boatURL = environment.url + "boats/";
  }


  public GetBoats(): Promise<Boat[]> {
    return new Promise<Boat[]>((resolve, reject) => {

      this.client.get(this.boatURL, this.accountService.getHttpHeaderOptions())
        .toPromise()
        .then((resultSets: any) => {
          resolve(resultSets as (Boat[]));

      }).catch(r => {
        reject(r);
      });
    });
  }

}
