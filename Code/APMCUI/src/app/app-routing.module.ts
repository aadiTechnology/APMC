import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { LoginComponent } from "./common-feature/components/login/login.component";
import { RegisterComponent } from "./common-feature/components/register/register.component";
import { LoginLayoutComponent } from "./shared/layouts/login-layout/login-layout.component";
import { MainLayoutComponent } from "./shared/layouts/main-layout/main-layout.component";

const routes: Routes = [
  {
    path: "",
    component: LoginLayoutComponent,
    children: [
      { path: "", redirectTo: "login", pathMatch: "full" },
      { path: "login", component: LoginComponent },
      { path: "register", component: RegisterComponent },
    ],
  },
  {
    path: "",
    component: MainLayoutComponent,
    children: [
      {
        path: "apmc",
        loadChildren: () =>
          import("./common-feature/common-feature.module").then(
            (m) => m.CommonFeatureModule
          ),
      },
      {
        path: "merchant",
        loadChildren: () =>
          import("./merchant/merchant.module").then((m) => m.MerchantModule),
      },
      {
        path: "admin",
        loadChildren: () =>
          import("./admin/admin.module").then((m) => m.AdminModule),
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
