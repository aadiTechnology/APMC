import { Component, OnInit, TemplateRef } from '@angular/core';
import { NgForm } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { MerchantService } from '../../../merchant.service';
import { ProductCategory } from '../../../entities/product-category';



@Component({
  selector: 'app-creat-indent',
  templateUrl: './creat-indent.component.html',
  styleUrls: ['./creat-indent.component.scss'],
})
export class CreatIndentComponent implements OnInit {
  selected: string;
  mytime: number;
  merchantindent: {
    productcategory:number;
    productlist: number;
    productquantity: number;
    productquantityunits:number;
    driverName: string;
    driverNumber: number;
    selectdte:number;
    vhclNumber: number;
    suplierName: string;
    suplierNumber: number;
  };
  procategory=[];
  driverlist = ['Rama Driver', 'Raju Driver', 'Balu Driver'];
  modalRef: BsModalRef;
  message: string;
  p = {  FieldProductCategory: 'Fruits', FieldProductQuantity:'1',FieldProductQuantityUnits:'Kilogram'};
  selectedProducts: any[];
  constructor(
      private modalService: BsModalService,
      private router: Router,
      private merchantService: MerchantService,
      private ngxSpinnerService: NgxSpinnerService,
      private toastr: ToastrService
      ) {
    this.merchantindent = {
      productcategory:null,
      productlist: null,
      productquantity: null,
      productquantityunits:null,
      driverName: null,
      driverNumber: null,
      selectdte:null,
      vhclNumber: null,
      suplierName: null,
      suplierNumber: null,
    };
    this.procategory=new Array<ProductCategory>();
    this.selectedProducts=new Array<any>();
  }

  ngOnInit(): void {
    this. getAllProductCategories();
  }
  
  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }
  onProductSelect(event): void {
    if(event){
     //  if (this.selectedProducts.length === 0) {
        this.selectedProducts.push(event);
   //   }
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
      if (form.valid) {
        const indentData = {};
        this.merchantService.indentCreation(indentData).subscribe(
          (arg) => {
            if (arg) {
              this.toastr.success('Indent Creation successful', 'Success');
              this.ngxSpinnerService.hide();
            }
          },
          (err) => {
            this.toastr.success('Something went wrong', 'Error');
            this.ngxSpinnerService.hide();
          }
        );
      } else {
        this.ngxSpinnerService.hide();
      }
    }
  
  confirm(): void {
    this.message = 'Confirmed!';
    this.router.navigate(['/login']);
    this.modalRef.hide();
  }

  decline(): void {
    this.message = 'Declined!';
    this.modalRef.hide();
  }

  getAllProductCategories(): void {
    this.merchantService.getAllProductCategories().subscribe((arg) => {
     
      if (arg) {
        this.procategory = arg;
        
      }
    });
  }
}
