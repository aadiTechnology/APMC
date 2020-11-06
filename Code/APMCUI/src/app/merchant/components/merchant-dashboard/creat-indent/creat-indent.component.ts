import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-creat-indent',
  templateUrl: './creat-indent.component.html',
  styleUrls: ['./creat-indent.component.scss']
})
export class CreatIndentComponent implements OnInit {

  selected: string;
  states = [
    'Rama Driver',
    'Raju Driver',
    'Balu Driver'
  ];
  constructor() { }

  ngOnInit(): void {
  }

}
