import {
  AfterViewInit,
  Component,
  OnInit,
  TemplateRef,
  ViewChild,
} from '@angular/core';
import { NgForm } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { MerchantService } from '../../../merchant.service';

import { DriverList } from '../../../entities/driverlist';

import { Merchantindent } from '../../../entities/merchantindent';
import { OrderDetailsComponent } from '../order-details/order-details.component';
import { CommonService } from 'src/app/common-feature/common.service';

@Component({
  selector: 'app-creat-indent',
  templateUrl: './creat-indent.component.html',
  styleUrls: ['./creat-indent.component.scss'],
})
export class CreatIndentComponent implements OnInit, AfterViewInit {
  selected: string;
  minDate: Date;
  currentUser: any; // session Cureent User
  ETATime = '6:00 am';
  driverlist = [];
  modalRef: BsModalRef;
  message: string;
  selectedProducts: any;
  merchantindent: Merchantindent;

  @ViewChild(OrderDetailsComponent) orderDetails;

  constructor(
    private modalService: BsModalService,
    private router: Router,
    private merchantService: MerchantService,
    private ngxSpinnerService: NgxSpinnerService,
    private toastr: ToastrService,
    private commonService: CommonService
  ) {
    this.minDate = new Date();
    this.currentUser = JSON.parse(sessionStorage.getItem('CurrentUser'));
    this.merchantindent = new Merchantindent();
    this.driverlist = new Array<DriverList>();
  }

  ngOnInit(): void {
    this.getAllGetAllDrivers();
  }

  ngAfterViewInit(): void {
    this.selectedProducts = this.orderDetails.selectedProducts;
  }

  getAllGetAllDrivers(): void {
    this.merchantService.getAllGetAllDrivers().subscribe((arg) => {
      if (arg) {
        this.driverlist = arg.rows;
      }
    });
  }

  getToday(): string {
    return new Date().toISOString().split('T')[0];
  }

  createIndent(form: NgForm): void {
    this.ngxSpinnerService.show();
    if (form.valid && this.selectedProducts.length !== 0) {
      const IndentDetails = {
        RollId: this.currentUser.id,
        CreatedBy: this.currentUser.roleId,
        DriverName: this.merchantindent.DriverName,
        DriverNo: this.merchantindent.DriverNo,
        ETADate: this.merchantindent.ETADate,
        ETATime: this.merchantindent.ETATime,
        VehicleNo: this.merchantindent.VehicleNo,
        SupplierName: this.merchantindent.SupplierName,
        SupplierNo: this.merchantindent.SupplierNo,
      };
      const indentData = {
        IndentProducts: this.selectedProducts,
        IndentDetails: IndentDetails,
      };
      this.merchantService.indentCreation(indentData).subscribe(
        (arg: any) => {
          if (!arg.HasErrors) {
            form.resetForm();
            this.toastr.success('Indent Creation successful', 'Success');
            this.ngxSpinnerService.hide();
          } else {
            this.toastr.error('Indent Creation failed', 'Error');
            this.ngxSpinnerService.hide();
          }
        },
        (err) => {
          this.toastr.error('Something went wrong', 'Error');
          this.ngxSpinnerService.hide();
        }
      );
    } else if (this.selectedProducts.length === 0) {
      this.toastr.error('Please create indent details', 'Error');
      this.ngxSpinnerService.hide();
    } else {
      this.toastr.error('Please provide required details', 'Error');
      this.ngxSpinnerService.hide();
    }
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.message = 'Confirmed!';
    this.commonService.goBack();
    this.modalRef.hide();
  }

  decline(): void {
    this.message = 'Declined!';
    this.modalRef.hide();
  }
}
