import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalService } from 'ngx-bootstrap/modal';
import { ExitGateServiceService } from '../../exit-gate-service.service';
import { InVehicle } from '../../entities/InVehicle'
 
@Component({
  selector: 'app-vehicle-list',
  templateUrl: './vehicle-list.component.html',
  styleUrls: ['./vehicle-list.component.scss']
})
export class VehicleListComponent implements OnInit {
  LVehicleList:any;
  message: string;
  modalRef: any;
  term: string;



  constructor(private modalService: BsModalService,
              private router: Router,
              private exitGateServiceService:ExitGateServiceService) { 

                this.LVehicleList= new Array<InVehicle>();
              }

  ngOnInit(): void {
    this. getAllStallRegistration()
  }
  

  getAllStallRegistration(): void {
    this.exitGateServiceService.GetAllCheckInVehicalDetails().subscribe((arg) => {
      if (arg) {
        this.LVehicleList = arg.rows;
      }
    });
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: "modal-sm" });
  }

  confirm(): void {
    this.message = "Confirmed!";
    this.router.navigate(["/exitGateOperator/dashboard"]);
    this.modalRef.hide();
  }

  decline(): void {
    this.message = "Declined!";
    this.modalRef.hide();
  }
}
