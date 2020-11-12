import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminDashboardRoutingModule } from './admin-dashboard-routing.module';
import { AdminDashboardComponent } from './admin-dashboard.component';
import { StallRegistrationRequestsComponent } from './components/stall-registration-requests/stall-registration-requests.component';


@NgModule({
  declarations: [AdminDashboardComponent, StallRegistrationRequestsComponent],
  imports: [
    CommonModule,
    AdminDashboardRoutingModule
  ]
})
export class AdminDashboardModule { }
