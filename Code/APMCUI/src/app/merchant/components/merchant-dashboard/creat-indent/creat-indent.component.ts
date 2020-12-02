import { Component, OnInit, TemplateRef, ViewChild } from "@angular/core";
import { NgForm } from "@angular/forms";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { Router } from "@angular/router";
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { MerchantService } from "../../../merchant.service";

import { DriverList } from "../../../entities/driverlist";

import { Merchantindent } from "../../../entities/merchantindent";
import { OrderDetailsComponent } from "../order-details/order-details.component";

@Component({
  selector: "app-creat-indent",
  templateUrl: "./creat-indent.component.html",
  styleUrls: ["./creat-indent.component.scss"],
})
export class CreatIndentComponent implements OnInit {
  selected: string;
  minDate: Date;
  currentUser: any; // session Cureent User
  ETATime = "6:00 am";
  driverlist = [];
  modalRef: BsModalRef;
  message: string;
  selectedProducts: any;
  merchantindent: Merchantindent;

  @ViewChild(OrderDetailsComponent) orderDetails;

  constructor(
    private modalService: BsModalService,
    private router: Router,
    private merchantService: MerchantService,
    private ngxSpinnerService: NgxSpinnerService,
    private toastr: ToastrService
  ) {
    this.minDate = new Date();
    this.currentUser = JSON.parse(sessionStorage.getItem("CurrentUser"));
    this.merchantindent = new Merchantindent();
    this.driverlist = new Array<DriverList>();
  }

  ngOnInit(): void {
    this.getAllGetAllDrivers();
  }

  ngAfterViewInit() {
    this.selectedProducts = this.orderDetails.selectedProducts;
  }

  getAllGetAllDrivers(): void {
    this.merchantService.getAllGetAllDrivers().subscribe((arg) => {
      if (arg) {
        this.driverlist = arg.rows;
      }
    });
  }

  getToday(): string {
    return new Date().toISOString().split("T")[0];
  }

  createIndent(form: NgForm): void {
    this.ngxSpinnerService.show();
    if (form.valid && this.selectedProducts.length !== 0) {
      const IndentDetails = {
        RollId: this.currentUser.id,
        CreatedBy: this.currentUser.roleId,
        DriverName: this.merchantindent.DriverName,
        DriverNo: this.merchantindent.DriverNo,
        ETADate: this.merchantindent.ETADate,
        ETATime: this.merchantindent.ETATime,
        VehicleNo: this.merchantindent.VehicleNo,
        SupplierName: this.merchantindent.SupplierName,
        SupplierNo: this.merchantindent.SupplierNo,
      };
      const indentData = {
        IndentProducts: this.selectedProducts,
        IndentDetails: IndentDetails,
      };
      this.merchantService.indentCreation(indentData).subscribe(
        (arg) => {
          if (arg) {
            this.toastr.success("Indent Creation successful", "Success");
            //  alert(JSON.stringify(arg));
            this.ngxSpinnerService.hide();
          }
          form.resetForm();
        },
        (err) => {
          this.toastr.error("Something went wrong", "Error");
          this.ngxSpinnerService.hide();
        }
      );
    } else {
      this.ngxSpinnerService.hide();
      this.toastr.error("Please create indent details");
    }
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: "modal-sm" });
  }

  confirm(): void {
    this.message = "Confirmed!";
    this.router.navigate(["/login"]);
    this.modalRef.hide();
  }

  decline(): void {
    this.message = "Declined!";
    this.modalRef.hide();
  }
}
