import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-creat-indent',
  templateUrl: './creat-indent.component.html',
  styleUrls: ['./creat-indent.component.scss']
})
export class CreatIndentComponent implements OnInit {

  selected: string;
  quser:{ 
    squantity:number;
  }
  states = [
    'Rama Driver',
    'Raju Driver',
    'Balu Driver'
  ];
  constructor() {
    this.quser={
      squantity:null,
    }
   }

  ngOnInit(): void {
  }
  onProductSelect(){
    
  }
  removeProduct(){
    
  }
}
