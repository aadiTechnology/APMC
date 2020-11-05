import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StallRegistrationComponent } from './components/merchant-dashboard/stall-registration/stall-registration.component';

import { MerchantComponent } from './merchant.component';

const routes: Routes = [{ path: '', component: MerchantComponent,
children: [
  { path: '**', redirectTo: 'stallregistration', pathMatch: 'full' },
  { path: 'stallregistration', component: StallRegistrationComponent }
]

}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MerchantRoutingModule { }
