import { TemplateRef } from "@angular/core";
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { AdminService } from "../../../admin.service";
import {StallRequestList} from "../../../entities/stallrequestlist";


@Component({
  selector: "app-stall-registration-list",
  templateUrl: "./stall-registration-list.component.html",
  styleUrls: ["./stall-registration-list.component.scss"],
})
export class StallRegistrationListComponent implements OnInit {
  stallRequestList:any;
  modalRef: BsModalRef;
  message: string;
  constructor(private modalService: BsModalService,
               private router: Router,
                private adminservice:AdminService) {

                  this.stallRequestList = new Array<StallRequestList>();
                }

  ngOnInit(): void {
    this.getAllStallRegistration();
  }
  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: "modal-sm" });
  }

  confirm(): void {
    this.message = "Confirmed!";
    this.router.navigate(["/admin/dashboard"]);
    this.modalRef.hide();
  }

  decline(): void {
    this.message = "Declined!";
    this.modalRef.hide();
  }

  getAllStallRegistration(): void {
    this.adminservice.getAllStallRegistration().subscribe((arg)=> {
      if(arg){
        this.stallRequestList = arg.rows;
      }
    });
  }

  ApproveStall(requestList): void{
    this.router.navigate(['/admin/dashboard/stallRegistrationRequests'],{state: {requestList: requestList}})
  }
}
