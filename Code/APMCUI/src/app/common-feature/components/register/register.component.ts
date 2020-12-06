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
  Role: any;
  hide: boolean = true;
  hidee: boolean = true;
  user: {
    RoleId: string;
    FirstName: string;
    LastName: string;
    MobileNo: number;
    Email: string;
    UserName: string;
    Password: string;
    ConfirmPassword: string;
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
      RoleId: null,
      FirstName: null,
      LastName: null,
      MobileNo: null,
      Email: null,
      UserName: null,
      Password: null,
      ConfirmPassword: null,
    };
    this.Role = new Array<AllAppUserRole>();
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
    if (this.user.Password !== null) {
      if (
        this.user.Password !== null ||
        this.user.Password.length === this.user.ConfirmPassword.length ||
        this.user.Password.length < this.user.ConfirmPassword.length
      ) {
        return this.user.Password === this.user.ConfirmPassword ? true : false;
      }
    } else {
      return true;
    }
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
    this.commonService.getAllUserRolls().subscribe((result) => {
      this.Role = result.rows;
    });
  }
}
