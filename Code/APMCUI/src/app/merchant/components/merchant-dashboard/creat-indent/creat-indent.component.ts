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
  ETATime = "6:00 am";
  product: {
    categoryId: number;
    categoryName: string;
    productId: number;
    productName: string;
    quantity: number;
    unit: string;
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
    Quantity: number;
    Unit: string;
  };
  constructor(
    private modalService: BsModalService,
    private router: Router,
    private merchantService: MerchantService,
    private ngxSpinnerService: NgxSpinnerService,
    private toastr: ToastrService
  ) {
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
      categoryId: null,
      categoryName: null,
      productId: null,
      productName: null,
      quantity: null,
      unit: null,
    };
    this.indent = {
      CategoryId: null,
      ProductId: null,
      Quantity: null,
      Unit: null,
    };
    this.selectedProducts = new Array<{
      categoryId: number;
      categoryName: string;
      productId: number;
      productName: string;
      quantity: number;
      unit: string;
    }>();
    this.procategory = new Array<ProductCategory>();
    this.productlist = new Array<ProductList>();
    this.driverlist = new Array<DriverList>();
    this.unitlist = new Array<UnitList>();
  }

  ngOnInit(): void {
    this.getAllProductCategories();
    this.getAllUnits();
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: "modal-sm" });
  }
  onProductSelect(prod, form: NgForm): void {
    if (prod && form.valid) {
      this.selectedProducts.push(prod);
      form.reset();
      this.indent = {
        CategoryId: null,
        ProductId: null,
        Quantity: null,
        Unit: null,
      };
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
        productcategory: +this.merchantindent.productcategory,
        productlist: +this.merchantindent.productlist,
        productquantity: +this.merchantindent.productquantity,
        Unit: +this.merchantindent.Unit,
        DriverName: +this.merchantindent.DriverName,
        DriverNo: +this.merchantindent.DriverNo,
        ETADate: +this.merchantindent.ETADate,
        ETATime: +this.merchantindent.ETATime,
        VehicleNo: +this.merchantindent.VehicleNo,
        SupplierName: +this.merchantindent.SupplierName,
        SupplierNo: +this.merchantindent.SupplierNo,
      };
      this.merchantService.indentCreation(indentData).subscribe(
        (arg) => {
          if (arg) {
            this.toastr.success("Indent Creation successful", "Success");
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
    this.router.navigate(["/login"]);
    this.modalRef.hide();
  }

  decline(): void {
    this.message = "Declined!";
    this.modalRef.hide();
  }

  onCategoryChange(event): void {
    const category = this.procategory.filter(
      (x) => x.id === +event.target.value
    )[0];
    this.product.categoryId = +category.id;
    this.product.categoryName = category.category;
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
    this.product.productId = prod.id;
    this.product.productName = prod.productName;
    this.selected = null;
  }
  onQuantity(event): void {
    if (event) {
      this.product.quantity = event.target.value;
    }
  }
  onUnitsChange(event): void {
    if (event) {
      this.product.unit = event.target.value;
    }
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
