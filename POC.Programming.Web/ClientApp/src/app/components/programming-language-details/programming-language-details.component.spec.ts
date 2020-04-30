import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ProgrammingLanguageDetailsComponent } from './programming-language-details.component';
import { NO_ERRORS_SCHEMA } from '@angular/core';

describe('ProgrammingLanguageDetailsComponent', () => {
  let component: ProgrammingLanguageDetailsComponent;
  let fixture: ComponentFixture<ProgrammingLanguageDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      declarations: [ ProgrammingLanguageDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProgrammingLanguageDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
