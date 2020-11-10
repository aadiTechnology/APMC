import { Injectable } from '@angular/core';
import { HttpService } from '../core/services/http.service';

@Injectable({
  providedIn: 'root',
})
export class 
CommonService {
  isSidebarPinned = false;
  isSidebarToggeled = false;
  constructor(private httpService: HttpService) {}

  toggleSidebar(): void {
    this.isSidebarToggeled = !this.isSidebarToggeled;
  }

  toggleSidebarPin(): void {
    this.isSidebarPinned = !this.isSidebarPinned;
  }

  getSidebarStat(): any {
    return {
      isSidebarPinned: this.isSidebarPinned,
      isSidebarToggeled: this.isSidebarToggeled,
    };
  }

  login(user): any {
    const loginUser = { UserName: user.UserName, Password: user.Password };
    return this.httpService.postAnonymous('Account/Login', loginUser);
  }

  signup(user): any {
    const registeruser = {
      UserName: user.userName,
      Password: user.password,
      FirstName: user.firstName,
      MobileNo: user.mobileNumber,
      LastName: user.lastName,
      Email: user.email,
      RoleId: +user.roleId,
    };
    return this.httpService.postAnonymous('Account/Register', registeruser);
  }
}
