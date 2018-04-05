import { Component, OnInit } from '@angular/core';
import { AccountService } from "app/account.service";
import { Router } from "@angular/router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  query: boolean = false; //loading
  username: string = '';
  password: string = '';
  error: string = '';

  constructor(private account: AccountService, private router : Router) { }

  doLogin() {
    this.query = true; //is loading...
    this.account.authenticate(this.username, this.password).then(() => {
      this.query = false;
      //alert("Authenticated!");

      this.router.navigate(["/reservations"]);


    }).catch(r => {
      this.error = "Unable to authenticate.";
      this.query = false;
    });
  }

  ngOnInit() {
  }

}
