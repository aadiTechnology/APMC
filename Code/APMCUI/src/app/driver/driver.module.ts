import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DriverRoutingModule } from './driver-routing.module';
import { DriverComponent } from './driver.component';
import { DriverDashboardComponent } from './components/driver-dashboard/driver-dashboard.component';
import { IndentQRListComponent } from './components/indent-qrlist/indent-qrlist.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { QrDetailsComponent } from './components/qr-details/qr-details.component';


@NgModule({
  declarations: [DriverComponent, DriverDashboardComponent, IndentQRListComponent, QrDetailsComponent],
  imports: [
    CommonModule,
    DriverRoutingModule,    
    PaginationModule.forRoot(),

  ]
})
export class DriverModule { }
