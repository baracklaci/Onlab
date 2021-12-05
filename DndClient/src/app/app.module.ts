import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HomeComponent } from './home/home.component';
import { ProfileComponent } from './profile/profile.component';
import { SheetComponent } from './sheet/sheet.component';
import { RegisterComponent } from './register/register.component';
import { ExistingSheetsComponent } from './existing-sheets/existing-sheets.component';
import { CharacterSheetComponent } from './character-sheet/character-sheet.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FeatureSkillComponent } from './feature-skill/feature-skill.component';
import { SpellComponent } from './spell/spell.component';
import { AddSpellComponent } from './add-spell/add-spell.component';
import { SpellHeaderComponent } from './spell-header/spell-header.component';
import { PlayRoomComponent } from './play-room/play-room.component';
import { GenerateRoomComponent } from './generate-room/generate-room.component';
import { ChooseCharacterComponent } from './choose-character/choose-character.component';

export function tokenGetter() {
  return localStorage.getItem('jwt');
}

@NgModule({
  declarations: [
    AppComponent,
    LoginFormComponent,
    NavbarComponent,
    HomeComponent,
    ProfileComponent,
    SheetComponent,
    RegisterComponent,
    ExistingSheetsComponent,
    CharacterSheetComponent,
    FeatureSkillComponent,
    SpellComponent,
    AddSpellComponent,
    SpellHeaderComponent,
    PlayRoomComponent,
    GenerateRoomComponent,
    ChooseCharacterComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ['localhost:5000'],
        disallowedRoutes: []
      }
    }),
    FontAwesomeModule,
    NgbModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
