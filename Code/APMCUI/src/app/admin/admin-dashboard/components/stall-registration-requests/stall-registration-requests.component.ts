import { TemplateRef } from "@angular/core";
import { Component, OnInit } from "@angular/core";
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from "@angular/router";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { AdminService } from "../../../admin.service";

@Component({
  selector: "app-stall-registration-requests",
  templateUrl: "./stall-registration-requests.component.html",
  styleUrls: ["./stall-registration-requests.component.scss"],
})
export class StallRegistrationRequestsComponent implements OnInit {
  currentUser: any; // session Cureent User
  modalRef: BsModalRef;
  message: string;
  Approverow: any;
  stallId:string;

  aprroveStalldata :{
    id:number;
    stallId: string;
    approveBy:number;
    isApproved:boolean;
    isRejected:boolean;
   
  };

  constructor(private modalService: BsModalService,
              private adminService: AdminService,
              private activatedRoute: ActivatedRoute,
              private ngxSpinnerService: NgxSpinnerService,
              private toastr: ToastrService,
               private router: Router) 
               {
              this.currentUser = JSON.parse(sessionStorage.getItem("CurrentUser"));
               this.aprroveStalldata= {
                  id:null,
                  stallId: null,
                  approveBy:this.currentUser.id,
                  isApproved:null,
                  isRejected:null,
                 
                };
               }
  
  ngOnInit(): void {
    this.stallId=this.activatedRoute.snapshot.queryParams.stallId;
    this.getAllStallRegistrationById(this.stallId);
    
  }
  getAllStallRegistrationById(Id){
    this.adminService.getAllStallRegistrationById(Id).subscribe((arg) => {
      if(arg){
        this.Approverow=arg.rows[0];
      }
    })
  }

  approveStall(form: NgForm): void{
    if(form.valid){
    this.ngxSpinnerService.show();
    
        const aprroveStalldata = {
          id:this.Approverow.id,
          stallId: this.Approverow.stallId,
          approveBy:this.currentUser.id,
          isApproved:true,
          isRejected:false,
          rejectReason:null
        };
        this.adminService.stallRegistrationApprove(aprroveStalldata).subscribe(
          (arg) => {
            if (arg) {
              this.toastr.success(arg.message,"Success");
              this.ngxSpinnerService.hide();
            }
          },
          (err) => {
            this.toastr.error("Something went wrong", "Error");
            this.ngxSpinnerService.hide();
          }
        );
      } 
  
    }


  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: "modal-sm" });
  }

  confirm(): void {
    this.message = "Confirmed!";
    this.router.navigate(["/admin/dashboard/stallRegistrationList"]);
    this.modalRef.hide();
  }

  decline(): void {
    this.message = "Declined!";
    this.modalRef.hide();
  }
}
