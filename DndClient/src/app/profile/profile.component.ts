import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ApplicationUserHeader, UserService } from '../client-generated';
import { SheetService } from '../client-generated';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  userEmail: string | undefined;
  userName: string | null;
  friends: string[] | undefined;
  friendRequest: boolean;
  sheets: string[] | undefined;
  firstName: string | undefined;
  lastName: string | undefined;
  userService = new UserService(this.http, undefined);
  sheetService = new SheetService(this.http, undefined);

  constructor(private http: HttpClient) { 
    this.userName = "";
    this.friendRequest = true;
  }

  ngOnInit(): void {
    this.userName = localStorage.getItem('username');
    this.userService.getUser(this.userName).subscribe(data => {
      console.log(data);
      this.userEmail = data.email;
      this.friends = data.friends;
      this.friendRequest = data.friendRequest;
      this.firstName = data.firstName;
      this.lastName = data.lastName;
    });
    this.sheetService.getSheets(this.userName).subscribe(data => {
      this.sheets = data;
    })
  }

  checkboxChanged() {
    this.friendRequest = !this.friendRequest;
    this.sendData();
  }

  sendData() {
    var data = new ApplicationUserHeader({
      email: this.userEmail,
      userName: this.userName ?? undefined,
      friends: this.friends,
      firstName: this.firstName,
      lastName: this.lastName,
      friendRequest: this.friendRequest
    });
    console.log(this.friendRequest)
    this.userService.updateUser(this.userName, data).subscribe(data => {
      console.log(data)
    })
  }

}
