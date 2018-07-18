import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-pipe',
  templateUrl: './pipe.component.html',
  styleUrls: ['./pipe.component.css']
})
export class PipeComponent implements OnInit {

  myName = "Manik";
  today = new Date();
  arr = ["Manik", "Prasad", "Venkat", "Subbu"];

  constructor() { }

  ngOnInit() {
  }

}
