import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DriverRoutingModule } from './driver-routing.module';
import { DriverComponent } from './driver.component';
import { DriverDashboardComponent } from './components/driver-dashboard/driver-dashboard.component';
import { IndentQRListComponent } from './components/indent-qrlist/indent-qrlist.component';


@NgModule({
  declarations: [DriverComponent, DriverDashboardComponent, IndentQRListComponent],
  imports: [
    CommonModule,
    DriverRoutingModule
  ]
})
export class DriverModule { }
