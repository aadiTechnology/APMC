import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { MerchantRoutingModule } from './merchant-routing.module';
import { MerchantComponent } from './merchant.component';
import { MerchantDashboardComponent } from './components/merchant-dashboard/merchant-dashboard.component';
import { StallRegistrationComponent } from './components/merchant-dashboard/stall-registration/stall-registration.component';

import { TypeaheadModule } from 'ngx-bootstrap/typeahead';
import { ModalModule } from 'ngx-bootstrap/modal';


@NgModule({
  declarations: [MerchantComponent, MerchantDashboardComponent, StallRegistrationComponent],
  imports: [
    CommonModule,FormsModule,
    MerchantRoutingModule,
    TypeaheadModule.forRoot(),
    ModalModule.forRoot(),
  ]
})
export class MerchantModule { }
