import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminDashboardRoutingModule } from './admin-dashboard-routing.module';
import { AdminDashboardComponent } from './admin-dashboard.component';
import { StallRegistrationRequestsComponent } from './components/stall-registration-requests/stall-registration-requests.component';
import { RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { StallRegistrationListComponent } from './components/stall-registration-list/stall-registration-list.component';
import { FormsModule } from "@angular/forms";

@NgModule({
  declarations: [AdminDashboardComponent, StallRegistrationRequestsComponent, DashboardComponent, StallRegistrationListComponent],
  imports: [
    CommonModule,
    AdminDashboardRoutingModule,
    RouterModule,
    FormsModule
  ]
})
export class AdminDashboardModule { }
