import { Injectable } from '@angular/core';
import { HttpService } from '../core/services/http.service';

@Injectable({
  providedIn: 'root',
})
export class MerchantService {
  constructor(private httpService: HttpService) {}

  getAllProductCategories(): any {
    return this.httpService.get('Merchant/GetAllProductCategory');
  }

  stallRegistration(data): any {
    return this.httpService.post('Merchant/StallRegistration', data);
  }
  indentCreation(indentData){
    return this.httpService.post('Indent/Add', indentData);
  }
}
