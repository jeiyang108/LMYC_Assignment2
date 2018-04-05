import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { environment } from "environments/environment";

@Injectable()
export class AccountService {

  private url: string;
  private token: string;
  private _isAuthenticated: boolean;

  /* Same as:

    private client = HttpClient

    constructor(client: HttpClient) {
      this.client -  client
    }
  */
  constructor(private client: HttpClient) {
    this.url = environment.url + "account/";
  }

  public getHttpHeaderOptions(): any {
    return {
      headers: new HttpHeaders({
        'Authorization': 'Bearer ' + this.token
      })
    };
  }

  //may be deleted in the future
  public isAuthenticated() {
    return this._isAuthenticated;
  }



  public authenticate(username: string, password: string): Promise<string> {
    return new Promise<string>((resolve, reject) => {
      var loginCredentials: any = {
        Username: username,
        Password: password
      };

      this.client.post(this.url, loginCredentials)
        .toPromise()
        .then((r: string) => { //r: token

          if (r.length == 0)
            return reject("Invalid login credentials.");

          this._isAuthenticated = true;
          this.token = r;
      
          resolve(r);

      }).catch(r => {
        //fails.
        reject(r);
        });
    });


  }


}
