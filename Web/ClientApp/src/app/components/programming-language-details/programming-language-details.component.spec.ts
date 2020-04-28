import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProgrammingLanguageDetailsComponent } from './programming-language-details.component';

describe('ProgrammingLanguageDetailsComponent', () => {
  let component: ProgrammingLanguageDetailsComponent;
  let fixture: ComponentFixture<ProgrammingLanguageDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
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
