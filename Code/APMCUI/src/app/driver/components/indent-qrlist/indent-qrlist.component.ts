import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-indent-qrlist',
  templateUrl: './indent-qrlist.component.html',
  styleUrls: ['./indent-qrlist.component.scss']
})
export class IndentQRListComponent implements OnInit {
  myDate = Date.now();    //date 
  constructor() { }

  ngOnInit(): void {
  }

}
