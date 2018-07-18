import { Component, OnInit } from '@angular/core';
import {FormGroup, FormControl} from '@angular/forms';

@Component({
  selector: 'app-forms',
  templateUrl: './forms.component.html',
  styleUrls: ['./forms.component.css']
})
export class FormsComponent implements OnInit {

  form; //This is required for Model driven forms
  constructor() { }

  ngOnInit() {
    //Below section is required for Model driven forms
    this.form = new FormGroup({
      firstname: new FormControl("Manik"),
      lastname: new FormControl(""),
      languages: new FormControl('')
    });
  }

  onSubmit(user){
    console.log(user);
  }
}
