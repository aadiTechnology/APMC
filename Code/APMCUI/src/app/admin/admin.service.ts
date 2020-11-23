import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from '../core/services/http.service';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  isSidebarPinned = false;
  isSidebarToggeled = false;

  constructor(private httpService: HttpService) { }

  

  getAllStallRegistration(): any {
    return this.httpService.get('Admin/GetAllStallRegistration');
  }

  getAllStallRegistrationById(Id): any {
    return this.httpService.get(`Admin/GetStallRegistrationById?Id=${Id}`);
  }

  stallRegistrationApprove(data): Observable<any> {
    return this.httpService.post('Admin/UpdateStallRegistration', data);
  }
}
