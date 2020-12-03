import { Injectable } from '@angular/core';
import { HttpService } from '../core/services/http.service';
import { Location } from '@angular/common';

@Injectable({
  providedIn: 'root',
})
export class CommonService {
  isSidebarPinned = false;
  isSidebarToggeled = false;
  constructor(private httpService: HttpService, private location: Location) {}

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
      UserName: user.UserName,
      Password: user.Password,
      FirstName: user.FirstName,
      MobileNo: user.MobileNo,
      LastName: user.LastName,
      Email: user.Email,
      RoleId: +user.RoleId,
    };
    return this.httpService.postAnonymous('Account/Register', registeruser);
  }
  getAllUserRolls(): any {
    return this.httpService.get('Account/GetAllUserRolls');
  }

  goBack(): void {
    this.location.back();
  }
}
