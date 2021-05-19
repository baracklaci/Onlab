import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { LoginService } from '../client-generated'
import { Router } from '@angular/router'

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  username = "";
  email = "";
  password = "";
  passwordAgain = "";
  userExists: boolean = false;
  
  loginService: LoginService = new LoginService(this.http);

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(data: any) {
    if (this.password !== this.passwordAgain){
      alert("The passwords do not match!");
      return;
    }
    this.loginService.register(data).subscribe(data => {
      const token = data.token;
      localStorage.setItem('jwt', <string>token);
      localStorage.setItem('username', this.username);
      this.router.navigate(['/']);
      this.userExists = false;
    }, (err: any) => {
      this.userExists = true;
      console.log('this user already exists');
    })
  }

}
