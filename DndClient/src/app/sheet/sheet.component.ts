import { Component, OnInit, } from '@angular/core';

import { CharacterSheet, SheetService, Weapon } from '../client-generated'
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-sheet',
  templateUrl: './sheet.component.html',
  styleUrls: ['./sheet.component.css']
})
export class SheetComponent implements OnInit {

  deleteSure: boolean = false;

  sheetName?: string;

  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.sheetName = params['characterName'];
    })
  }
  showWarning() {
    this.deleteSure = true;
  }

}
