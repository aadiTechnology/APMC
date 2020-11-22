import { TemplateRef } from "@angular/core";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { AdminService } from "../../../admin.service";

@Component({
  selector: "app-stall-registration-requests",
  templateUrl: "./stall-registration-requests.component.html",
  styleUrls: ["./stall-registration-requests.component.scss"],
})
export class StallRegistrationRequestsComponent implements OnInit {
  modalRef: BsModalRef;
  message: string;
  Approverow: any;
  stallId:string;

  constructor(private modalService: BsModalService,
              private adminService: AdminService,
              private activatedRoute: ActivatedRoute,
               private router: Router) {}
  
  ngOnInit(): void {
    this.stallId=this.activatedRoute.snapshot.queryParams.stallId;
    this.getAllStallRegistrationById(this.stallId);
    
  }
  getAllStallRegistrationById(Id){
    this.adminService.getAllStallRegistrationById(Id).subscribe((arg) => {
      if(arg){
        this.Approverow=arg.rows;
      }
    })
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
