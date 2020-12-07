import { formatDate } from '@angular/common';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute,Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Exitgate } from "../../entities/exitGate";
import { ExitGateServiceService } from "../../exit-gate-service.service";
import {UpdateParkingCharge} from "../../entities/updateParkingCharge";
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

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
               private ngxSpinnerService: NgxSpinnerService,
               private exitGateServiceService:ExitGateServiceService,
               private activeRoute:ActivatedRoute,
               private toastr: ToastrService
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
//Only Signature
  exitgate(form: NgForm):void {
    this.ngxSpinnerService.show();
    if(form.valid){
      const charges={

      }
    this.exitGateServiceService.UpdateParkingCharges(this.vehicleEntryRow).subscribe(
      (arg)=>{
        if(arg){
          this.toastr.success("Save SuccessFully","Success");
          this.GetCheckInVehicleDetailsById(this.indentId)
          this.ngxSpinnerService.hide();
        }
        form.resetForm();
      },
      (err) => {
        this.toastr.error("Something went wrong","Error");
        this.ngxSpinnerService.hide();
      }
      );
     }
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
