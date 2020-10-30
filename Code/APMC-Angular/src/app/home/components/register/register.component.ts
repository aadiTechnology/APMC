import { Component, ContentChild, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { IonInput } from '@ionic/angular';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  showPassword = false;
  showConfirmPassword = false;
  @ContentChild(IonInput) input: IonInput;
  user: {
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

  register(form: NgForm) {
    if (form.valid) {
      // do something
    }
  }
}
