import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { StallRegistrationRequestsComponent } from "./admin-dashboard/components/stall-registration-requests/stall-registration-requests.component";

import { AdminComponent } from "./admin.component";

const routes: Routes = [
  { path: "", redirectTo: "dashboard", pathMatch: "full" },
  {
    path: "dashboard",
    loadChildren: () =>
      import("./admin-dashboard/admin-dashboard.module").then(
        (m) => m.AdminDashboardModule
      ),
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdminRoutingModule {}
