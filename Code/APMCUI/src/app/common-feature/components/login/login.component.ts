import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { CommonService } from '../../common.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  user: { UserName: string; Password: string };
  constructor(private commonService: CommonService, private router: Router) {
    this.user = {
      UserName: null,
      Password: null,
    };
  }

  ngOnInit(): void {}
  login(form: NgForm, user): any {
    if (form.valid) {
      this.commonService.login(user).subscribe((arg) => {
        if (arg) {
          console.log(user.UserName,user.Password);
          sessionStorage.setItem('AccessToken', arg.token);
          
          this.router.navigate(['/merchant']);
        }
      });
    }
  }
}
