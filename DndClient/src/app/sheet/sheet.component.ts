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

  sheetService = new SheetService(this.http, undefined);
  characterSheet: CharacterSheet = new CharacterSheet()
  userName: string | null = '';
  sheetName: string | null = '';
  add: boolean = false;
  deleteSure: boolean = false;
  valuesMissing = false;

  constructor(private http: HttpClient, private route: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.characterSheet.init();
    console.log(this.characterSheet);
    this.characterSheet.characterName = '';
    this.userName = localStorage.getItem('username');
    this.route.queryParams.subscribe(params => {
      this.add = params['new'];
    })
    this.route.params.subscribe(params => {
      this.sheetName = params['characterName'];
    })
    if (this.sheetName){
      this.sheetService.getSheet(this.userName, this.sheetName).subscribe(data => {
      if(data === undefined){
        alert('no data')
      }
      this.characterSheet = data;
      this.sheetName = data.characterName ?? null;
    }, error => {
      alert('this charactersheet doesnt exist');
      this.router.navigate(['']);
    });
    }
    
  }

  addWeapon() {
    if (this.characterSheet.weapons == undefined){
      this.characterSheet.weapons = [];
    }
    this.characterSheet.weapons?.push(new Weapon());
  }

  removeWeapon(weapon: Weapon) {
    var idx = this.characterSheet.weapons?.indexOf(weapon);
    if (idx !== undefined && idx > -1) {
      this.characterSheet.weapons?.splice(idx, 1);
    }
  }

  isSheetValid() {
    if (this.characterSheet.characterName === undefined){
      return false;
    }
    if (this.characterSheet.str == undefined){
      return false;
    }
    if (this.characterSheet.dex == undefined){
      return false;
    }
    if (this.characterSheet.con == undefined){
      return false;
    }
    if (this.characterSheet.int == undefined){
      return false;
    }
    if (this.characterSheet.wis == undefined){
      return false;
    }
    if (this.characterSheet.cha == undefined){
      return false;
    }
    return true;
  }

  saveSheet() {
    if (!this.isSheetValid()){
      this.valuesMissing = true;
      alert('some values are missing');
      return;
    }
    console.log(this.characterSheet);
    if (this.add){
      this.sheetService.newSheet(this.userName, this.characterSheet).subscribe(() => {
        alert('saved');
      });
      this.add = false;
    }
    else {
      this.sheetService.updateSheet(this.userName, this.sheetName ?? this.characterSheet.characterName ?? null, this.characterSheet).subscribe(() => {
        alert('saved');
      });
    }
  }

  getModifier(value: number) {
    return (value - 10)/2;
  }

  fillValues() {
    if (this.characterSheet.str) this.characterSheet.athletics = this.characterSheet.strSave = this.getModifier(this.characterSheet.str);
    if (this.characterSheet.dex) this.characterSheet.stealth = this.characterSheet.sleightOfHand = this.characterSheet.acrobatics = this.characterSheet.dexSave = this.getModifier(this.characterSheet.dex);
    if (this.characterSheet.con) this.characterSheet.conSave = this.getModifier(this.characterSheet.con);
    if (this.characterSheet.int) this.characterSheet.arcana = this.characterSheet.religion = this.characterSheet.nature = this.characterSheet.investigation = this.characterSheet.history = this.characterSheet.intSave = this.getModifier(this.characterSheet.int);
    if (this.characterSheet.wis) this.characterSheet.survival = this.characterSheet.perception = this.characterSheet.medicine = this.characterSheet.insight = this.characterSheet.animalHandling = this.characterSheet.wisSave = this.getModifier(this.characterSheet.wis);
    if (this.characterSheet.cha) this.characterSheet.persuasion = this.characterSheet.performance = this.characterSheet.intimidation = this.characterSheet.deception = this.characterSheet.chaSave = this.getModifier(this.characterSheet.cha);


  }

  showWarning() {
    this.deleteSure = true;
  }

  deleteSheet() {
    this.sheetService.deleteSheet(this.userName, this.sheetName).subscribe(() => {
      alert('deleted');
    })
  }

}
