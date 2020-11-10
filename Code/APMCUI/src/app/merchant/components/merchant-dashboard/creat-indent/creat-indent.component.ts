import { Component, OnInit, TemplateRef } from '@angular/core';
import { NgForm } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Router } from '@angular/router';

import { from } from 'rxjs';

@Component({
  selector: 'app-creat-indent',
  templateUrl: './creat-indent.component.html',
  styleUrls: ['./creat-indent.component.scss'],
})
export class CreatIndentComponent implements OnInit {
  selected: string;
  // What is quser?  declare variable with proper name
  quser: {
    productlist: number;
    squantity: number;
    driverName: string;
    driverNumber: number;
    vhclNumber: number;
    suplierName: string;
    suplierNumber: number;
  };
  // what are states?
  states = ['Rama Driver', 'Raju Driver', 'Balu Driver'];
  modalRef: BsModalRef;
  message: string;
  constructor(
    private modalService: BsModalService,
      private router: Router) {
    this.quser = {
      productlist: null,
      squantity: null,
      driverName: null,
      driverNumber: null,
      vhclNumber: null,
      suplierName: null,
      suplierNumber: null,
    };
  }

  ngOnInit(): void {}
  
  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }
  onProductSelect(): void {}
  removeProduct(): void {}
  createIndent(form: NgForm, quser): void {
    if (form.valid) {
      console.log(form.value);
    } else {
      console.log(form.value);
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
}
