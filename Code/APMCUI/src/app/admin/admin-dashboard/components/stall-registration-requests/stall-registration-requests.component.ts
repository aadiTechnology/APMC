import { TemplateRef } from "@angular/core";
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";

@Component({
  selector: "app-stall-registration-requests",
  templateUrl: "./stall-registration-requests.component.html",
  styleUrls: ["./stall-registration-requests.component.scss"],
})
export class StallRegistrationRequestsComponent implements OnInit {
  modalRef: BsModalRef;
  message: string;
  requestList: any;

  constructor(private modalService: BsModalService, private router: Router) {}
  
  ngOnInit(): void {
    this.requestList=history.state.requestList;
    
  }
  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: "modal-sm" });
  }

  confirm(): void {
    this.message = "Confirmed!";
    this.router.navigate(["/admin/dashboard/getAllstallRegistrationList"]);
    this.modalRef.hide();
  }

  decline(): void {
    this.message = "Declined!";
    this.modalRef.hide();
  }
}
