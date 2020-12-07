import { Injectable } from '@angular/core';
import { HttpService } from '../core/services/http.service';

@Injectable({
  providedIn: 'root'
})
export class DriverService {

  constructor(private httpService: HttpService) { }

  getIndentWithMerchantName():any{
    return this.httpService.get('Indent/GetIndentWithMerchantName');
  }
}
