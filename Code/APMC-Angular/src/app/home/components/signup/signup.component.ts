import { Component, ContentChild, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { IonInput } from '@ionic/angular';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
})
export class SignupComponent implements OnInit {

  showPassword = false;
  showConfirmPassword = false;
  @ContentChild(IonInput) input: IonInput;
  user: {
    role:string,
    firstName: string;
    lastName: string;
    mobileNumber: string;
    email: string;
    userName: string;
    password: string;
    confirmPassword: string;
  };
  constructor() {
    this.user = {
      role:null,
      firstName: null,
      lastName: null,
      mobileNumber: null,
      email: null,
      userName: null,
      password: null,
      confirmPassword: null,
    };
  }

  ngOnInit() {}

  togglePasswordShow(input: any) {
    this.showPassword = !this.showPassword;
    input.type = this.showPassword ? 'text' : 'password';
  }
  toggleConfirmPasswordShow(input: any) {
    this.showConfirmPassword = !this.showConfirmPassword;
    input.type = this.showConfirmPassword ? 'text' : 'password';
  }
  checkPassword() {
    return this.user.password === this.user.confirmPassword ? true : false;
  }

  signUp(form: NgForm) {
    if (form.valid) {
      // do something
      console.log(form.value)
    }
  }
}
