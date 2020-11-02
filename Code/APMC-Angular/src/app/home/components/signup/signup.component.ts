import { Component, ContentChild, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { IonInput } from '@ionic/angular';
import { HomeService } from '../../home.service';
import { Router } from '@angular/router';

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
    roleId:number;
    firstName: string;
    lastName: string;
    mobileNumber: string;
    email: string;
    userName: string;
    password: string;
    confirmPassword: string;
  };
  constructor(private homeService: HomeService, private router: Router) {
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

  signup(form: NgForm,user) {
    if (form.valid) {
      console.log(form.value)
      this.homeService.signup(user).subscribe((arg) => {
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
}
