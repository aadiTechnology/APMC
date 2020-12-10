import { Injectable } from '@angular/core';
import { HttpService } from '../../core/services/http.service';

@Injectable({
  providedIn: 'root',
})
export class EntryGateOperatorService {
  constructor(private httpService: HttpService) {}
  getAllIndentDetails(Id): any {
    return this.httpService.get(`EntryGate/IndentDetailsById?Id=${Id}`);
  }
  getIndentDetails(Id): any {
    return this.httpService.get(`Indent/GetIndentDetails?indentId=${+Id}`);
  }
  getAllNotScannedIndent(): any {
    return this.httpService.get('EntryGate/GetAllNotScannedIndent');
  }

  GetDetailsByQRCode(indentId, merchantId, driverId): any {
    return this.httpService.get(
      `Indent/GetIndent?indented=${indentId}&merchantId=${merchantId}&driverId=${driverId}`
    );
  }
}
// https://apmcdata.azurewebsites.net/api/Indent/GetIndentDetails?indentId=2
