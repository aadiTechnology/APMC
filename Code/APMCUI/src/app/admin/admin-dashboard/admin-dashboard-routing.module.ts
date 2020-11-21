import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { AdminDashboardComponent } from "./admin-dashboard.component";
import { StallRegistrationListComponent } from './components/stall-registration-list/stall-registration-list.component';
import { StallRegistrationRequestsComponent } from "./components/stall-registration-requests/stall-registration-requests.component";
import { DashboardComponent } from './dashboard/dashboard.component';

const routes: Routes = [
  { path: "",  component: DashboardComponent},
  {
    path: "stallRegistrationRequests",
    component: StallRegistrationRequestsComponent,
  },
  {
    path: "getAllstallRegistrationList",
    component: StallRegistrationListComponent,
  },
  {
    path: "dashboard",
    component: DashboardComponent,
    
  },
  {
    path:"StallRegistrationList",
    component:StallRegistrationListComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminDashboardRoutingModule {}
