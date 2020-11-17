import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { AdminDashboardComponent } from "./admin-dashboard.component";
import { StallRegistrationRequestsComponent } from "./components/stall-registration-requests/stall-registration-requests.component";
import { DashboardComponent } from './dashboard/dashboard.component';

const routes: Routes = [
  { path: "", redirectTo: "stallRegistrationRequests", pathMatch: "full" },
  {
    path: "stallRegistrationRequests",
    component: StallRegistrationRequestsComponent,
  },
  {
    path: "dashboard",
    component: DashboardComponent,
    
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminDashboardRoutingModule {}
