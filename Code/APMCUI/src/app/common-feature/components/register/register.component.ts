import { Component, OnInit, TemplateRef } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { CommonService } from '../../common.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  hide: boolean = true;
  user: {
    roleId:number;
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
  constructor(private modalService: BsModalService,private commonService: CommonService,private router: Router
    ) {
    this.user = {
      roleId:null,
      firstName: null,
      lastName: null,
      mobileNumber: null,
      email: null,
      userName: null,
      password: null,
      confirmPassword: null,
    };

   }
   openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }
  ngOnInit(): void {
  }
  myFunction(){
    this.hide = !this.hide;
  }
  
  checkPassword() {
    return this.user.password === this.user.confirmPassword ? true : false;
  }
 signup(form: NgForm,user) {
    if (form.valid) {
      console.log(form.value)
      this.commonService.signup(user).subscribe((arg) => {
        if (arg) {
          sessionStorage.setItem('AccessToken', arg.token);
          this.router.navigate(['/merchant']);
        }
      });
    }
    else{
      console.log(form.value)
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
}

