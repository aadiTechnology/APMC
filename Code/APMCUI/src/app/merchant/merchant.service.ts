import { Token } from '@angular/compiler/src/ml_parser/lexer';
import { Injectable } from '@angular/core';
import { HttpService } from '../core/services/http.service';

@Injectable({
  providedIn: 'root'
})
export class MerchantService {

  constructor(private httpService: HttpService) { }

getAllStallDetails(){
  return this.httpService.get('Merchant/GetAllStallDetails');
}          

getGetAllProductCategory(){
  return this.httpService.get('Merchant/GetAllProductCategory');
}

GetUserDataById(){
  
}

}
