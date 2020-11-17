import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminDashboardRoutingModule } from './admin-dashboard-routing.module';
import { AdminDashboardComponent } from './admin-dashboard.component';
import { StallRegistrationRequestsComponent } from './components/stall-registration-requests/stall-registration-requests.component';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';


@NgModule({
  declarations: [AdminDashboardComponent, StallRegistrationRequestsComponent, DashboardComponent],
  imports: [
    CommonModule,
    AdminDashboardRoutingModule,
    RouterModule,
  ]
})
export class AdminDashboardModule { }
