import { Component, OnInit, TemplateRef } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { CommonService } from '../../common.service';
import { AllAppUserRole } from '../../entities/userrole';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {

  Role:any;
  hide: boolean = true;
  hidee: boolean = true;
  user: {
    roleId: number;
    firstName: string;
    lastName: string;
    mobileNumber: string;
    email: string;
    userName: string;
    password: string;
    confirmPassword: string;
  };
  modalRef: BsModalRef;
  message: string;
  
  constructor(
    private modalService: BsModalService,
    private commonService: CommonService,
    private router: Router,
    private ngxSpinnerService: NgxSpinnerService,
    private toastr: ToastrService
  ) {
    this.user = {
      roleId: null,
      firstName: null,
      lastName: null,
      mobileNumber: null,
      email: null,
      userName: null,
      password: null,
      confirmPassword: null,
    };
    this.Role=new Array<AllAppUserRole>();

  }
  ngOnInit(): void {
    this.getAllUserRolls();
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }
  myFunction(): void {
    this.hide = !this.hide;
  }
  myFunctionCp(): void {
    this.hidee = !this.hidee;
  }
  

  checkPassword(): boolean {
    return this.user.password === this.user.confirmPassword ? true : false;
  }

  signup(form: NgForm, user): void {
    this.ngxSpinnerService.show();
    if (form.valid) {
      console.log(form.value);
      this.commonService.signup(user).subscribe(
        (arg) => {
          if (arg) {
            this.router.navigate(['/login']);
            this.toastr.success('Registration successful', 'Success');
            this.ngxSpinnerService.hide();
          }
        },
        (err) => {
          this.toastr.success('Something went wrong', 'Error');
          this.ngxSpinnerService.hide();
        }
      );
    } else {
      console.log(form.value);
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
  getAllUserRolls(): void {
    this.commonService.getAllUserRolls().subscribe(result => { this.Role = result.rows });
    
  }
}
