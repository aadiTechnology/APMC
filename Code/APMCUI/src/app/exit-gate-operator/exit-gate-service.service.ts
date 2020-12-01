import { Injectable } from '@angular/core';
import { HttpService } from '../core/services/http.service';


@Injectable({
  providedIn: 'root'
})
export class ExitGateServiceService {

  constructor(private httpService: HttpService) { }

  GetAllCheckInVehicalDetails(): any {
    return this.httpService.get('ExitGate/GetAllCheckInVehicleDetails');
  }

  GetCheckInVehicleDetailsById(Id): any {
    return this.httpService.get(`ExitGate/GetCheckInVehicleDetailsById?Id=${Id}`);
  }

}
