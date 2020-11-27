import { formatDate } from '@angular/common';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Exitgate } from "../../entities/exitGate";
@Component({
  selector: 'app-exit-gate',
  templateUrl: './exit-gate.component.html',
  styleUrls: ['./exit-gate.component.scss']
})
export class ExitGateComponent implements OnInit {
  selected: string;
  modalRef: BsModalRef; //cancel model
  message: string;
  VehicleNo:string;

  today = new Date();
  todaysDataTime = "";
  exitGate=[];

  constructor( private modalService: BsModalService, private router: Router,) { 
    this.exitGate = new Array<Exitgate>();
    this.VehicleNo=null;
    this.todaysDataTime = formatDate(
      this.today,
      " hh:mm:ss a",
      "en-US",
      "+0530"
    );
  }

  ngOnInit(): void {
  }

  
  states: string[] = [
    'MH14EX9044',
    'MH12DK7454',
    'MH12ST0005',
    'MH16PQ0005',
  ];

 //Cancel button popup
 openModal(template: TemplateRef<any>): void {
  this.modalRef = this.modalService.show(template, { class: "modal-sm" });
}

confirm(): void {
  this.message = "Confirmed!";
  this.router.navigate(["exitGateOperator/dashboard"]);
  this.modalRef.hide();
}
decline(): void {
  this.message = "Declined!";
  this.modalRef.hide();
}
}
