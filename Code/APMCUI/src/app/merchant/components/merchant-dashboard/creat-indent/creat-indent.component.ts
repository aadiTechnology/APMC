import { Component, OnInit, TemplateRef } from "@angular/core";
import { NgForm } from "@angular/forms";
import { BsModalRef, BsModalService } from "ngx-bootstrap/modal";
import { Router } from "@angular/router";
import { NgxSpinnerService } from "ngx-spinner";
import { ToastrService } from "ngx-toastr";
import { MerchantService } from "../../../merchant.service";
import { ProductCategory } from "../../../entities/product-category";
import { ProductList } from "../../../entities/productlist";
import { DriverList } from "../../../entities/driverlist";
import { UnitList } from "../../../entities/unitlist";

@Component({
  selector: "app-creat-indent",
  templateUrl: "./creat-indent.component.html",
  styleUrls: ["./creat-indent.component.scss"],
})
export class CreatIndentComponent implements OnInit {
  selected: string;
  currentUser: any; // session Cureent User
  ETATime = "6:00 am";
  product: {
    CategoryId: number;
    CategoryName: string;
    ProductId: number;
    ProductName: string;
    ProductQuantity: number;
    Unit: string;
    UnitId: number;
  };
  selectedProducts: any[];
  merchantindent: {
    productcategory: number;
    productlist: number;
    productquantity: number;
    Unit: number;
    DriverName: string;
    DriverNo: number;
    ETADate: number;
    ETATime: string;
    VehicleNo: number;
    SupplierName: string;
    SupplierNo: number;
  };
  procategory = [];
  productlist = [];
  driverlist = [];
  unitlist = [];
  modalRef: BsModalRef;
  message: string;
  indent: {
    CategoryId: number;
    ProductId: number;
    ProductQuantity: number;
    UnitId: number;
  };
  constructor(
    private modalService: BsModalService,
    private router: Router,
    private merchantService: MerchantService,
    private ngxSpinnerService: NgxSpinnerService,
    private toastr: ToastrService
  ) {
    this.currentUser = JSON.parse(sessionStorage.getItem("CurrentUser"));
    this.merchantindent = {
      productcategory: null,
      productlist: null,
      productquantity: null,
      Unit: null,
      DriverName: null,
      DriverNo: null,
      ETADate: null,
      ETATime: null,
      VehicleNo: null,
      SupplierName: null,
      SupplierNo: null,
    };
    this.product = {
      CategoryId: null,
      CategoryName: null,
      ProductId: null,
      ProductName: null,
      ProductQuantity: null,
      Unit: null,
      UnitId: null,
    };
    this.indent = {
      CategoryId: null,
      ProductId: null,
      ProductQuantity: null,
      UnitId: null,
    };
    this.selectedProducts = new Array<{
      CategoryId: number;
      categoryName: string;
      ProductId: number;
      ProductName: string;
      ProductQuantity: number;
      UnitId: number;
    }>();

    this.procategory = new Array<ProductCategory>();
    this.productlist = new Array<ProductList>();
    this.driverlist = new Array<DriverList>();
    this.unitlist = new Array<UnitList>();
  }

  ngOnInit(): void {
    this.getAllProductCategories();
    this.getAllUnits();
    this.getAllGetAllDrivers();
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: "modal-sm" });
  }
  onProductSelect(prod, form: NgForm): void {
    if (prod && form.valid) {
      const p = JSON.parse(JSON.stringify(prod));
      this.selectedProducts.push(p);

      this.indent = {
        CategoryId: null,
        ProductId: null,
        ProductQuantity: null,
        UnitId: null,
      };
      form.resetForm();
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
  createIndent(form: NgForm): void {
    this.ngxSpinnerService.show();
    if (form.valid && this.selectedProducts.length !== 0) {
      const indentData = {
        IndentProducts:this.selectedProducts,
        RollId:this.currentUser.id,
        CreatedBy:this.currentUser.roleId,
        DriverName: this.merchantindent.DriverName,
        DriverNo: this.merchantindent.DriverNo,
        ETADate: this.merchantindent.ETADate,
        ETATime: this.merchantindent.ETATime,
        VehicleNo: this.merchantindent.VehicleNo,
        SupplierName: this.merchantindent.SupplierName,
        SupplierNo: this.merchantindent.SupplierNo,       
      
      };
      this.merchantService.indentCreation(indentData).subscribe(
        (arg) => {
          if (arg) {
            this.toastr.success("Indent Creation successful", "Success");
           alert(JSON.stringify(arg));
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
    }
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
  getToday(): string {
    return new Date().toISOString().split('T')[0]
 }

  onCategoryChange(event): void {
    const category = this.procategory.filter(
      (x) => x.id === +event.target.value
    )[0];
    this.product.CategoryId = +category.id;
    this.product.CategoryName = category.category;
    if (category) {
      this.merchantService
        .getAllProducts(category.id)
        .subscribe((procategory) => {
          if (procategory) {
            this.productlist = procategory.rows;
          }
        });
    } else {
      this.productlist = null;
    }
  }
  onProductSelected(event): void {
    const prod = this.productlist.filter(
      (p) => p.id === +event.target.value
    )[0];
    this.product.ProductId = prod.id;
    this.product.ProductName = prod.productName;
    this.selected = null;
  }
  onQuantity(event): void {
    if (event) {
      this.product.ProductQuantity = event.target.value;
    }
  }
  onUnitsChange(event): void {
    const unit = this.unitlist.filter(
      (x) => x.id === +event.target.value
    )[0];
    this.product.UnitId = +unit.id;
    this.product.Unit = unit.unit;
  }

  getAllProductCategories(): void {
    this.merchantService.getAllProductCategories().subscribe((arg) => {
      if (arg) {
        this.procategory = arg.rows;
      }
    });
  }
  getAllProducts(CategoryId): void {
    this.merchantService.getAllProducts(CategoryId).subscribe((arg) => {
      if (arg) {
        this.productlist = arg.rows;
      }
    });
  }

  getAllUnits(): void {
    this.merchantService.getAllUnits().subscribe((arg) => {
      if (arg) {
        this.unitlist = arg.rows;
      }
    });
  }

  getAllGetAllDrivers(): void {
    this.merchantService.getAllGetAllDrivers().subscribe((arg) => {
      if (arg) {
        this.driverlist = arg.rows;
      }
    });
  }
}
