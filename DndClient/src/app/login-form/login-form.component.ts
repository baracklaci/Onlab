import { Component, Inject, OnInit } from '@angular/core';
import { Router } from '@angular/router'
import { HttpClient } from '@angular/common/http';
import { LoginService } from '../client-generated'
import { SignalrService } from '../services/signalr.service';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {
  invalidLogin = false;
  username: string = "";
  password: string = "";
  loginService: LoginService = new LoginService(this.http);

  constructor(private signalrService: SignalrService, private router: Router, private http: HttpClient) { }

  ngOnInit(): void {
  }

  onSubmit(data: any)
  {
    console.log(data)
    this.loginService.login(data).subscribe(async data => {
      const token = data.token;
      localStorage.setItem('jwt', <string>token);
      localStorage.setItem('username', this.username);
      //await this.signalrService.startConnection();
      this.signalrService.enteredSite(this.username);
      this.invalidLogin = false;
      this.router.navigate(['/']);
      console.log('success');
    }, (err: any) => {
      this.invalidLogin = true;
      console.log('bad username or password');
    })
  }
}
