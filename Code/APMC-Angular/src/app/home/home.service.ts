import { Injectable } from '@angular/core';
import { HttpService } from '../core/services/http.service';

@Injectable({
  providedIn: 'root',
})
export class HomeService {
  constructor(private httpService: HttpService) {}

  login(user) {
    const loginUser = { UserName: user.UserName, Password: user.Password };
    return this.httpService.postAnonymous('Account/Login', loginUser);
  }
}
