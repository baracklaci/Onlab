import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { SheetService } from '../client-generated';

@Component({
  selector: 'app-existing-sheets',
  templateUrl: './existing-sheets.component.html',
  styleUrls: ['./existing-sheets.component.css']
})
export class ExistingSheetsComponent implements OnInit {

  sheetService = new SheetService(this.http, undefined);
  userName: string | null;
  sheets?: string[];

  constructor(private http: HttpClient) {
    this.userName = '';
   }

  ngOnInit(): void {
    this.userName = localStorage.getItem('username');
    this.sheetService.getSheets(this.userName).subscribe(data => {
      this.sheets = data;
      console.log(data);
    })
  }

}
