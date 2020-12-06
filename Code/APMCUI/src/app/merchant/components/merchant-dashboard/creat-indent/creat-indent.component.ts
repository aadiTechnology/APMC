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
import { Product } from 'src/app/merchant/entities/product';

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
  IndentDetails: any;
  driverName: string;
  @ViewChild(OrderDetailsComponent) orderDetails;
  roles: any;

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
    this.driverName = null;
  }

  ngOnInit(): void {
    this.getAllUserRoles();
    this.getAllGetAllDrivers();
  }

  ngAfterViewInit(): void {
    this.selectedProducts = this.orderDetails.selectedProducts;
  }

  getAllGetAllDrivers(): void {
    this.ngxSpinnerService.show();
    this.merchantService.getAllGetAllDrivers().subscribe(
      (arg) => {
        if (!arg.HasErrors) {
          this.driverlist = arg.rows;
          this.ngxSpinnerService.hide();
        } else {
          this.ngxSpinnerService.hide();
        }
      },
      (err) => {
        this.ngxSpinnerService.hide();
      }
    );
  }

  getToday(): string {
    return new Date().toISOString().split('T')[0];
  }

  createIndent(form: NgForm): void {
    this.ngxSpinnerService.show();
    if (form.valid && this.selectedProducts.length !== 0) {
      const indentDetails = {
        RollId: this.currentUser.id,
        CreatedBy: this.currentUser.id,
        DriverID: this.merchantindent.DriverId,
        DriverNo: this.merchantindent.DriverNo,
        ETADate: this.merchantindent.ETADate,
        ETATime: this.merchantindent.ETATime,
        VehicleNo: this.merchantindent.VehicleNo,
        SupplierName: this.merchantindent.SupplierName,
        SupplierNo: this.merchantindent.SupplierNo,
      };
      const indentData = {
        IndentProducts: this.selectedProducts,
        IndentDetails: indentDetails,
      };
      this.merchantService.indentCreation(indentData).subscribe(
        (arg: any) => {
          if (!arg.HasErrors) {
            form.resetForm();
            this.toastr.success(arg.message, 'Success');
            this.ngxSpinnerService.hide();
            this.selectedProducts = new Array<Product>();
            this.orderDetails.selectedProducts = new Array<Product>();
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
  getAllUserRoles(): void {
    this.commonService.getAllUserRolls().subscribe((result) => {
      this.roles = result.rows;
    });
  }
  onDriverSelect(event): void {
    if (event) {
      debugger;
      if (event.item.id !== null && event.item.id !== undefined) {
        this.merchantindent.DriverId = event.item.id;
      } else {
        const registeruser = {
          UserName: event.item,
          Password: null,
          FirstName: event.item,
          MobileNo: null,
          LastName: null,
          Email: null,
          RoleId: +this.roles.filter((u) => u.roleName === 'Driver')[0].id,
        };
        this.commonService.signup(registeruser).subscribe((arg) => {
          if (arg) {
            debugger;
          }
        });
      }
    }
  }
}
