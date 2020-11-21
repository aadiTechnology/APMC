import { Injectable } from '@angular/core';
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
}
