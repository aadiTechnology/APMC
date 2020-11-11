import { Component, OnInit, TemplateRef } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { MerchantService } from '../../../merchant.service';
@Component({
  selector: 'app-stall-registration',
  templateUrl: './stall-registration.component.html',
  styleUrls: ['./stall-registration.component.scss'],
})
export class StallRegistrationComponent implements OnInit {
  selected: string;
  productCAtergory = [];
  // [
  //   'Fruits',
  //   'Vegetables',
  //   'Flowers',
  //   'Dry Fruits',
  //   'Spices',
  //   'Fertilizers & Manures',
  //   'Dairy',
  //   'Packaging Material',
  //   'Farm Equipments',
  //   'Grains',
  //   'Fishery',
  //   'Pulses',
  //   'Cereals',
  // ];

  stallreg: {
    stallno: number;
    productcategory: string;
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
    this.stallreg = {
      stallno: null,
      productcategory: null,
    };
    this.productCAtergory = new Array<any>();
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }
  ngOnInit(): void {
    this.getAllProductCategories();
  }

  stallregister(form: NgForm): void {
    this.ngxSpinnerService.show();
    if (form.valid) {
      const stallData = {};
      this.merchantService.stallRegistration(stallData).subscribe(
        (arg) => {
          if (arg) {
            this.toastr.success('Stall registration successful', 'Success');
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
    this.router.navigate(['/merchant']);
    this.modalRef.hide();
  }
  decline(): void {
    this.message = 'Declined!';
    this.modalRef.hide();
  }

  getAllProductCategories(): void {
    this.merchantService.getAllProductCategories().subscribe((arg) => {
      if (arg) {
        this.productCAtergory = arg;
      }
    });
  }
}
