import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { CommonService } from '../../common.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  user: { UserName: string; Password: string };
  hide: boolean = true;
  constructor(
    private commonService: CommonService,
    private router: Router,
    private ngxSpinnerService: NgxSpinnerService,
    private toastr: ToastrService
  ) {
    this.user = {
      UserName: null,
      Password: null,
    };
  }
  

  ngOnInit(): void {}
  myFunction(): void {
    this.hide = !this.hide;
  }
  login(form: NgForm, user): any {
    this.ngxSpinnerService.show();
    if (form.valid) {
      this.commonService.login(user).subscribe(
        (arg) => {
          if (!arg.HasErrors) {
            
            sessionStorage.setItem('AccessToken', arg.token);
            
            sessionStorage.setItem('CurrentUser', JSON.stringify(arg));
            if (arg.role === 'Merchant') {
              this.router.navigate(['/merchant']);
            }else if (arg.role === 'Admin') {
              this.router.navigate(['/admin']);
            }else if (arg.role === 'ExitGateOperator') {
              this.router.navigate(['/exitGateOperator']);
            }
            this.ngxSpinnerService.hide();
          }
          else{
            
          this.toastr.error(arg.message, 'Error');
          this.ngxSpinnerService.hide();
          }
        },
        (err) => {
          this.toastr.success('Something went wrong', 'Error');
          this.ngxSpinnerService.hide();
        }
      );
    } else {
      this.ngxSpinnerService.hide();
    }
  }
}
