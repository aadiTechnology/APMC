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
  getAllProducts(CategoryId): any {
    return this.httpService.get(`Indent/GetProducts?CategoryId=${CategoryId}`);
  }
  getAllGetAllDrivers(): any {
    return this.httpService.get('Indent/GetAllDrivers');
  }
  getAllUnits(): any {
    return this.httpService.get('Indent/GetUnits');
  }

  stallRegistration(data): Observable<any> {
    return this.httpService.post('Merchant/StallRegistration', data);
  }
  indentCreation(indentData){
    return this.httpService.post('Indent/Add', indentData);
  }
}
