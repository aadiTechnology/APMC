import { Component, OnInit, TemplateRef } from "@angular/core";
import { NgForm } from "@angular/forms";
import { Router } from "@angular/router";

import { BsModalService, BsModalRef } from "ngx-bootstrap/modal";
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { MerchantService } from "../../../merchant.service";
import { StallDetails } from "../../../entities/stall-details";
import { ProductCategory } from "../../../entities/product-category";

@Component({
  selector: "app-stall-registration",
  templateUrl: "./stall-registration.component.html",
  styleUrls: ["./stall-registration.component.scss"],
})
export class StallRegistrationComponent implements OnInit {
  stalllist: any;
  productCategory: any;

  selected: string;
  productCatergory = [];

  currentUser: any;

  p = { Id: 1, ProductName: "Fishery" };
  selectedProducts: any[];

  stall: {
    UserId: number;
    StallId: number;
    Category: string;
  };

  modalRef: BsModalRef;
  message: string;

  constructor(
    private modalService: BsModalService,
    private router: Router,
    private merchantService: MerchantService,
    private ngxSpinnerService: NgxSpinnerService,
    private toastr: ToastrService
  ) {
    this.currentUser = JSON.parse(sessionStorage.getItem("CurrentUser"));
    this.stall = {
      UserId: this.currentUser.id,
      StallId: null,
      Category: null,
    };

    this.selectedProducts = [{ Id: 1, ProductName: "Fishery" }];

    this.stalllist = new Array<StallDetails>();
    this.productCategory = new Array<ProductCategory>();
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: "modal-sm" });
  }
  ngOnInit(): void {
    this.getAllProductCategories();
    this.getAllStallDetails();
  }

  onProductSelect(event): void {
    if (event) {
      // if (this.selectedProducts.length === 0) {
      this.selectedProducts.push(event);
      // }
    }
  }
  removeProduct(event): void {
    if (this.selectedProducts.length !== 0) {
      const index = this.selectedProducts.findIndex((x) => x.id === event.id);
      if (index !== -1) {
        this.selectedProducts.splice(index, 1);
      }
    }
  }

  stallregister(form: NgForm): void {
    this.ngxSpinnerService.show();
    if (form.valid) {
      const stallData = {
        UserId: +this.stall.UserId,
        StallId: +this.stall.StallId,
        Category: [+this.stall.Category],
      };
      this.merchantService.stallRegistration(stallData).subscribe(
        (arg) => {
          if (arg) {
            this.toastr.success("Stall registration successful", "Success");
            this.ngxSpinnerService.hide();
          }
        },
        (err) => {
          this.toastr.success("Something went wrong", "Error");
          this.ngxSpinnerService.hide();
        }
      );
    } else {
      this.ngxSpinnerService.hide();
    }
  }

  confirm(): void {
    this.message = "Confirmed!";
    this.router.navigate(["/merchant"]);
    this.modalRef.hide();
  }
  decline(): void {
    this.message = "Declined!";
    this.modalRef.hide();
  }

  getAllStallDetails() {
    this.merchantService.getAllStallDetails().subscribe((arg) => {
      if (arg) {
        this.stalllist = arg;
      }
    });
  }

  getAllProductCategories(): void {
    this.merchantService.getAllProductCategories().subscribe((arg) => {
      if (arg) {
        this.productCategory = arg;
      }
    });
  }

  onCategory(event) {
    this.stall.Category = event.item.id;
  }
}
