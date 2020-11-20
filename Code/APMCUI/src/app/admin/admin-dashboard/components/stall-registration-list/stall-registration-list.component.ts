import { TemplateRef } from "@angular/core";
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";

@Component({
  selector: "app-stall-registration-list",
  templateUrl: "./stall-registration-list.component.html",
  styleUrls: ["./stall-registration-list.component.scss"],
})
export class StallRegistrationListComponent implements OnInit {
  modalRef: BsModalRef;
  message: string;
  constructor(private modalService: BsModalService, private router: Router) {}

  ngOnInit(): void {}
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
}
