import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MerchantRoutingModule } from './merchant-routing.module';
import { MerchantComponent } from './merchant.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [MerchantComponent],
  imports: [CommonModule, MerchantRoutingModule, FormsModule],
})
export class MerchantModule {}
