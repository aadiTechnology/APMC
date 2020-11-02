import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { HomeService } from '../../home.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  user: { UserName:string; Password:string };
  showPassword: boolean;
  constructor(private homeService: HomeService, private router: Router) {
    this.user = {
      UserName: null,
      Password: null,
    };
  }
  ngOnInit() {}
  login(form: NgForm, user) {
    if (form.valid) {
      console.log(form.value)
      this.homeService.login(user).subscribe((arg) => {
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

  togglePasswordShow(input: any) {
    this.showPassword = !this.showPassword;
    input.type = this.showPassword ? 'text' : 'password';
  }
}
