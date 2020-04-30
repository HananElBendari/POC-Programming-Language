import { Component, OnInit, Input } from '@angular/core';
import { ProgrammingLanguageDetails } from '../../models/programming-language-details';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-programming-language-details',
  templateUrl: './programming-language-details.component.html',
  styleUrls: ['./programming-language-details.component.css']
})
export class ProgrammingLanguageDetailsComponent implements OnInit {

  @Input() programmingLanguageDetails: ProgrammingLanguageDetails;
  @Input() numberOfHits: number;

  constructor() { }

  ngOnInit() {
  }

}
