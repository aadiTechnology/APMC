import { Injectable } from '@angular/core';
import { HttpService } from '../core/services/http.service';

@Injectable({
  providedIn: 'root'
})
export class MerchantService {

  constructor(private httpService: HttpService) { }

getAllStallDetails(){
  return this.httpService.getAnonymous('Merchant/GetAllStallDetails');
}

}
