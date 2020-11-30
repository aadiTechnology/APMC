import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreatIndentComponent } from './components/merchant-dashboard/creat-indent/creat-indent.component';
import { MerchantDashboardComponent } from './components/merchant-dashboard/merchant-dashboard.component';
import { StallRegistrationComponent } from './components/merchant-dashboard/stall-registration/stall-registration.component';

import { MerchantComponent } from './merchant.component';

const routes: Routes = [
  {
    path: '',
    component: MerchantComponent,
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: 'dashboard', component: MerchantDashboardComponent },
      { path: 'stallregistration', component: StallRegistrationComponent },
      { path: 'creatindent', component: CreatIndentComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MerchantRoutingModule {}
