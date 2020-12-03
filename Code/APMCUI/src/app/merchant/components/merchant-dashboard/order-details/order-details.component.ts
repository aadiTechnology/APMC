import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MerchantService } from '../../../merchant.service';
import { Product } from '../../../entities/product';
import { Indent } from '../../../entities/indent';
import { ProductCategory } from 'src/app/merchant/entities/product-category';
import { ProductList } from 'src/app/merchant/entities/productlist';
import { UnitList } from 'src/app/merchant/entities/unitlist';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.scss'],
})
export class OrderDetailsComponent implements OnInit {
  selectedProducts: any[];
  procategory = [];
  productlist = [];
  unitlist = [];
  product: Product;
  indent: Indent;

  constructor(
    private merchantService: MerchantService,
    private ngxSpinnerService: NgxSpinnerService
  ) {
    this.product = new Product();
    this.indent = new Indent();
    this.selectedProducts = new Array<Product>();
    this.procategory = new Array<ProductCategory>();
    this.productlist = new Array<ProductList>();
    this.unitlist = new Array<UnitList>();
  }

  ngOnInit(): void {
    this.getAllProductCategories();
    this.getAllUnits();
  }
  getAllProductCategories(): void {
    this.merchantService.getAllProductCategories().subscribe((arg) => {
      if (arg) {
        this.procategory = arg.rows;
      }
    });
  }

  onCategoryChange(event): void {
    this.ngxSpinnerService.show();
    const category = this.procategory.filter(
      (x) => x.id === +event.target.value
    )[0];
    this.product.CategoryId = +category.id;
    this.product.CategoryName = category.category;
    if (category) {
      this.merchantService.getAllProducts(category.id).subscribe(
        (procategory) => {
          if (procategory) {
            this.productlist = procategory.rows;
            this.ngxSpinnerService.hide();
          }
        },
        (err) => {
          this.ngxSpinnerService.hide();
        }
      );
    } else {
      this.productlist = null;
      this.ngxSpinnerService.hide();
    }
  }

  getAllProducts(CategoryId): void {
    this.merchantService.getAllProducts(CategoryId).subscribe((arg) => {
      if (arg) {
        this.productlist = arg.rows;
      }
    });
  }

  onProductSelected(event): void {
    const prod = this.productlist.filter(
      (p) => p.id === +event.target.value
    )[0];
    this.product.ProductId = prod.id;
    this.product.ProductName = prod.productName;
  }

  getAllUnits(): void {
    this.merchantService.getAllUnits().subscribe((arg) => {
      if (arg) {
        this.unitlist = arg.rows;
      }
    });
  }
  onQuantity(event): void {
    if (event) {
      this.product.ProductQuantity = event.target.value;
    }
  }
  onUnitsChange(event): void {
    const unit = this.unitlist.filter((x) => x.id === +event.target.value)[0];
    this.product.UnitId = +unit.id;
    this.product.Unit = unit.unit;
  }

  onProductSelect(prod, form: NgForm): void {
    if (prod && form.valid) {
      const p = JSON.parse(JSON.stringify(prod));
      this.selectedProducts.push(p);
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
}
