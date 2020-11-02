import { Injectable } from '@angular/core';
import { HttpService } from '../core/services/http.service';

@Injectable({
  providedIn: 'root',
})
export class HomeService {
  constructor(private httpService: HttpService) {}

  login(user) {
    const loginUser = { UserName: user.userName, Password: user.password };
    return this.httpService.postAnonymous('Account/Login', loginUser);
  }

  signup(user)
  {
    const registeruser = { 
      UserName: user.userName, 
      Password: user.password,
      FirstName :user.firstName,
      MobileNo :user.mobileNumber,
      LastName :user.lastName,
      Email :user.email,
      RoleId :+user.roleId
     };
    return this.httpService.postAnonymous('Account/Register', registeruser);
  }

}
