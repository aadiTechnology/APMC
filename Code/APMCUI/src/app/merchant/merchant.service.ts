import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from '../core/services/http.service';

@Injectable({
  providedIn: 'root',
})
export class MerchantService {
  constructor(private httpService: HttpService) {}

  getAllStallDetails():any{
    return this.httpService.get('Merchant/GetAllStallDetails');
  }   

  getAllProductCategories(): any {
    return this.httpService.get('Merchant/GetAllProductCategory');
  }

  stallRegistration(data): Observable<any> {
    return this.httpService.post('Merchant/StallRegistration', data);
  }
  indentCreation(indentData){
    return this.httpService.post('Indent/Add', indentData);
  }
}
