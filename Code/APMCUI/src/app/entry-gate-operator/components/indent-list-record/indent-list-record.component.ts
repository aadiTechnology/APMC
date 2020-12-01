import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-indent-list-record',
  templateUrl: './indent-list-record.component.html',
  styleUrls: ['./indent-list-record.component.scss']
})
export class IndentListRecordComponent implements OnInit {
  myDate = Date.now();    //date 

  constructor() { }

  ngOnInit(): void {
  }

}
