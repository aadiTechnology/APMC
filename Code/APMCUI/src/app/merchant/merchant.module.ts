import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MerchantRoutingModule } from './merchant-routing.module';
import { MerchantComponent } from './merchant.component';
import { MerchantDashboardComponent } from './components/merchant-dashboard/merchant-dashboard.component';
import { StallRegistrationComponent } from './components/merchant-dashboard/stall-registration/stall-registration.component';


@NgModule({
  declarations: [MerchantComponent, MerchantDashboardComponent, StallRegistrationComponent],
  imports: [
    CommonModule,
    MerchantRoutingModule
  ]
})
export class MerchantModule { }
