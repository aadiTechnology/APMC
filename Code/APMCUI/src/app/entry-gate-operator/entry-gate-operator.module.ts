import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EntryGateOperatorRoutingModule } from './entry-gate-operator-routing.module';
import { EntryGateOperatorComponent } from './entry-gate-operator.component';
import { EntryGateOperatorDashboardComponent } from './components/entry-gate-operator-dashboard/entry-gate-operator-dashboard.component';
import { IndentListRecordComponent } from './components/indent-list-record/indent-list-record.component';
import { IndentDetailsComponent } from './components/indent-details/indent-details.component';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { FormsModule } from '@angular/forms';
import { NgxSpinnerModule } from 'ngx-spinner';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { IConfig, NgxMaskModule } from 'ngx-mask';
const maskConfig: Partial<IConfig> = {
  validation: false,
};
@NgModule({
  declarations: [
    EntryGateOperatorComponent,
    EntryGateOperatorDashboardComponent,
    IndentListRecordComponent,
    IndentDetailsComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    Ng2SearchPipeModule,
    EntryGateOperatorRoutingModule,
    PaginationModule.forRoot(),
    NgxSpinnerModule,
    NgxMaterialTimepickerModule,
    NgxMaskModule.forRoot(maskConfig),
  ],
})
export class EntryGateOperatorModule {}
