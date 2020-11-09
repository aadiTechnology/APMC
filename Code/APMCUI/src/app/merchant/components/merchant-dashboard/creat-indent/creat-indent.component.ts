import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { from } from 'rxjs';

@Component({
  selector: 'app-creat-indent',
  templateUrl: './creat-indent.component.html',
  styleUrls: ['./creat-indent.component.scss']
})
export class CreatIndentComponent implements OnInit {

  selected: string;
  quser:{ 
    productlist:number;
    squantity:number;
    driverName:string;
    driverNumber:number;
    vhclNumber:number
    suplierName:string;
    suplierNumber:number;

  }
  states = [
    'Rama Driver',
    'Raju Driver',
    'Balu Driver'
  ];
  constructor() {
    this.quser={
      productlist:null,   
      squantity:null,
      driverName:null,
      driverNumber:null,
      vhclNumber:null,
      suplierName:null,
      suplierNumber:null,
    }
   }

  ngOnInit(): void {
  }
  onProductSelect(){
    
  }
  removeProduct(){
    
  }
  createIndent(form:NgForm,quser){
    if (form.valid) {
      console.log(form.value);

  }else{
    console.log(form.value);
  }
}
}