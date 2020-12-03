import { formatDate } from '@angular/common';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute,Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Exitgate } from "../../entities/exitGate";
import { ExitGateServiceService } from "../../exit-gate-service.service";
import {UpdateParkingCharge} from "../../entities/updateParkingCharge";

@Component({
  selector: 'app-exit-gate',
  templateUrl: './exit-gate.component.html',
  styleUrls: ['./exit-gate.component.scss']
})
export class ExitGateComponent implements OnInit {
  modalRef: BsModalRef; //cancel model
  message: string;

  today = new Date();
  todaysDataTime = "";
  exitGate:any;
  indentId: any;
  vehicleEntryRow: any;
  updateParkingCharge: UpdateParkingCharge;

  constructor( private modalService: BsModalService,
               private router: Router,
               private exitGateServiceService:ExitGateServiceService,
               private activeRoute:ActivatedRoute,
               ) { 
        
     this.exitGate = new Array<Exitgate>();
    this.updateParkingCharge=new UpdateParkingCharge();
    this.todaysDataTime = formatDate(
      this.today,
      " hh:mm a",
      "en-US",
      "+0530"
    );
  }

  ngOnInit(): void {
    this.indentId=this.activeRoute.snapshot.queryParams.indentId;
    this.GetCheckInVehicleDetailsById(this.indentId)
  }

  GetCheckInVehicleDetailsById(Id){
    this.exitGateServiceService.GetCheckInVehicleDetailsById(Id).subscribe((arg)=>{
      if(arg){
        this.vehicleEntryRow=arg.rows[0];
      }
    })
  }

  exitgate(form: NgForm):void {

  }

 //Cancel button popup
 openModal(template: TemplateRef<any>): void {
  this.modalRef = this.modalService.show(template, { class: "modal-sm" });
}

confirm(): void {
  this.message = "Confirmed!";
  this.router.navigate(["/exitGateOperator/VehicleList"]);
  this.modalRef.hide();
}
decline(): void {
  this.message = "Declined!";
  this.modalRef.hide();
}
}
