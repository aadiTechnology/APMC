import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MerchantRoutingModule } from './merchant-routing.module';
import { MerchantComponent } from './merchant.component';
import { MerchantDashboardComponent } from './components/merchant-dashboard/merchant-dashboard.component';


@NgModule({
  declarations: [MerchantComponent, MerchantDashboardComponent],
  imports: [
    CommonModule,
    MerchantRoutingModule
  ]
})
export class MerchantModule { }
