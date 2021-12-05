import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SignalrService } from './services/signalr.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'DndClient';

  constructor(private signalrService: SignalrService, private router: Router){
    
  }
  async ngOnInit() {
    console.log("oninit")
    var username = localStorage.getItem('username');
    await this.signalrService.startConnection();
    
    if(username){
      this.signalrService.enteredSite(username);
    }
    
    this.signalrService.addInviteListener((message, url) => {
      this.showInvite = true;
      this.inviteMessage = message;
      this.inviteUrl = "/choose/" + url;
    })
  }

  accept(){
    this.showInvite = false;
    this.router.navigate([this.inviteUrl]);
  }

  decline(){
    this.showInvite = false;
  }

  inviteMessage: string;
  inviteUrl: string;
  showInvite = false;
}
