import { Component, OnChanges, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {JwtHelperService} from '@auth0/angular-jwt';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit{

  public signedIn = false;
  public username: string | null;

  constructor(private router: Router, private jwtHelper: JwtHelperService) {
    this.username = '';
   }

  ngOnInit(): void {
    var token = localStorage.getItem('jwt') ?? undefined;
    console.log(this.jwtHelper.isTokenExpired(token));
    if (token !== undefined){
      if (this.jwtHelper.isTokenExpired(token)){
        localStorage.removeItem('jwt');
      }
      else {
        this.signedIn = true;
        this.username = localStorage.getItem('username');
      }
     
    }
    
  }

  _signOut() {
    localStorage.removeItem('jwt');
    console.log('signed out');
    this.signedIn = false;
    this.router.navigate(['/']);
  }

}
