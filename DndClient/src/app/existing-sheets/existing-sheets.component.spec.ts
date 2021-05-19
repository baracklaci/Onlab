import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExistingSheetsComponent } from './existing-sheets.component';

describe('ExistingSheetsComponent', () => {
  let component: ExistingSheetsComponent;
  let fixture: ComponentFixture<ExistingSheetsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExistingSheetsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExistingSheetsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
