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
  currentUser: any; // session Cureent User
  stalllist: any; // stalllist
  productCategory: any; //product category list
  CategoryId: number;

  selected: string;
  productCatergory = [];

  //Category Details
  product: {
    categoryId: number;
    categoryName: string;
  };

  selectedProducts: any[];

  // Stall registration form entity
  stall: {
    UserId: number;
    StallId: number;
    Category: number[];
  };

  modalRef: BsModalRef; //cancel model
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
      Category: new Array<number>(),
    };
    this.product = {
      categoryId: null,
      categoryName: null,
    };

    this.selectedProducts = [];
    this.stalllist = new Array<StallDetails>();
    this.productCategory = new Array<ProductCategory>();
  }

  

  ngOnInit(): void {
    this.getAllProductCategories();
    this.getAllStallDetails();
  }

  onProductSelect(StallRegisterForm: NgForm, event): void {
    if (event!==null && event !=undefined) {
      if (this.selectedProducts.length === 0) {

      this.stall.Category.push(event);
      this.selectedProducts.push({ id: event, name: this.selected });
      
       }
       else{
         const index= this.selectedProducts.findIndex(p=>p.id===event);
         if (index!==-1) {
          this.toastr.error("Category already Present", "Error");
         } else {
          this.selectedProducts.push({ id: event, name: this.selected });
         }
       }
       this.CategoryId = null;
       this.selected = null;
       StallRegisterForm.controls["Pcategory"].reset();
  }
  else{
    this.toastr.error("Please Select Category ", "Error");
  }
}

  onCategory(event) {
    // this.stall.Category = event.item.category;
    this.CategoryId = event.item.id;
  }

  onCategoryChange(event) {
    const category = this.productCatergory.filter(
      (p) => p.id === +event.target.value
    )[0];
    this.product.categoryId = category.id;
    this.product.categoryName = category.category;
    
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
      if (this.stall.Category.length !== 0) {
        const stallData = {
          UserId: +this.stall.UserId,
          StallId: +this.stall.StallId,
          Category: this.stall.Category,
        };
        this.merchantService.stallRegistration(stallData).subscribe(
          (arg) => {
            if (arg) {
              this.toastr.success("Thank you for submitting your request Admin will get in touch with you shortly.", "Success");
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
        this.toastr.error("Please select correct category", "Error");
        this.ngxSpinnerService.hide();
      }
    } else {
      this.ngxSpinnerService.hide();
    }
      
  }
  

  getAllStallDetails():void {
    this.merchantService.getAllStallDetails().subscribe((arg) => {
      if (arg) {
        this.stalllist = arg.rows;
      }
    });
  }

  getAllProductCategories(): void {
    this.merchantService.getAllProductCategories().subscribe((arg) => {
      if (arg) {
        this.productCategory = arg.rows;
      }
    });
  }

  //Cancel button popup
  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: "modal-sm" });
  }

  confirm(): void {
    this.message = "Confirmed!";
    this.router.navigate(["/merchant/dashboard"]);
    this.modalRef.hide();
  }
  decline(): void {
    this.message = "Declined!";
    this.modalRef.hide();
  }
}
