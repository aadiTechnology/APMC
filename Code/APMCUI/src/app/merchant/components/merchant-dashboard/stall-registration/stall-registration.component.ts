import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';

import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-stall-registration',
  templateUrl: './stall-registration.component.html',
  styleUrls: ['./stall-registration.component.scss'],
})
export class StallRegistrationComponent implements OnInit {
  selected: string;
  productCAtergory = [
    'Fruits',
    'Vegetables',
    'Flowers',
    'Dry Fruits',
    'Spices',
    'Fertilizers & Manures',
    'Dairy',
    'Packaging Material',
    'Farm Equipments',
    'Grains',
    'Fishery',
    'Pulses',
    'Cereals',
  ];

  stallreg: {
    stallno: number;
    productcategory: string;
  };

  modalRef: BsModalRef;
  message: string;

  constructor(private modalService: BsModalService, private router: Router) {
    this.stallreg = {
      stallno: null,
      productcategory: null,
    };
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }
  ngOnInit(): void {}

  stallregister(any) {}

  confirm(): void {
    this.message = 'Confirmed!';
    this.router.navigate(['/merchant']);
    this.modalRef.hide();
  }
  decline(): void {
    this.message = 'Declined!';
    this.modalRef.hide();
  }
}
