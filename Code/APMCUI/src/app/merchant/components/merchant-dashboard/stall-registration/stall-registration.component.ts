import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { MerchantService } from '../../../merchant.service';
import { StallDetails } from '../../../entities/stall-details';
import { ProductCategory } from '../../../entities/product-category'

@Component({
  selector: 'app-stall-registration',
  templateUrl: './stall-registration.component.html',
  styleUrls: ['./stall-registration.component.scss']
})
export class StallRegistrationComponent implements OnInit {
  stalllist: any;
  productCatergory:any;

  selected: string;
  

  p = { Id: 1, ProductName: 'Fishery' };
  selectedProducts: any[];

  stallreg: {
    stallno: number;
    productcategory: string;
  };


  modalRef: BsModalRef; // cancel buton
  message: string;



  constructor(private modalService: BsModalService, private router: Router, private merchantService: MerchantService) {
    this.stallreg = {
      stallno: null,
      productcategory: null
    };

    this.selectedProducts = [
      { Id: 1, ProductName: 'Fishery' },
    ];
   
    this.stalllist = new Array<StallDetails>();
    this.productCatergory = new Array<ProductCategory>();
  }

  ngOnInit(): void {
    this.getAllStallDetails();
    this.getGetAllProductCategory();
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

  //Start form 
  stallregister(any) {

  }
  //end form

  //cancel button pop
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.message = 'Confirmed!';
    this.router.navigate(['/merchant']);
    this.modalRef.hide();
  }
  decline(): void {
    this.message = 'Declined!';
    this.modalRef.hide();
  }
  // end cancel button pop

    // start get form data
  getAllStallDetails() {
    this.merchantService.getAllStallDetails()
      .subscribe(result => { this.stalllist = result });
  }

  getGetAllProductCategory() {
    this.merchantService.getGetAllProductCategory()
      .subscribe(result => { this.productCatergory = result });
  }

  GetUserDataById(id) {
    
  }

    // end 


}
