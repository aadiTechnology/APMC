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
  getAllNotScannedIndent(): any {
    return this.httpService.get('EntryGate/GetAllNotScannedIndent');
  }

  GetDetailsByQRCode(indentId, merchantId, driverId): any {
    return this.httpService.get(
      `Indent/UpdateScanned?indentId=${indentId}&merchantId=${merchantId}&driverId=${driverId}`
    );
  }
}
