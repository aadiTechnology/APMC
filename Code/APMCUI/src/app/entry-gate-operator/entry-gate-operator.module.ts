import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EntryGateOperatorRoutingModule } from './entry-gate-operator-routing.module';
import { EntryGateOperatorComponent } from './entry-gate-operator.component';
import { EntryGateOperatorDashboardComponent } from './components/entry-gate-operator-dashboard/entry-gate-operator-dashboard.component';
import { IndentListRecordComponent } from './components/indent-list-record/indent-list-record.component';
import { IndentDetailsComponent } from './components/indent-details/indent-details.component';


@NgModule({
  declarations: [EntryGateOperatorComponent, EntryGateOperatorDashboardComponent, IndentListRecordComponent, IndentDetailsComponent, ],
  imports: [
    CommonModule,
    EntryGateOperatorRoutingModule
  ]
})
export class EntryGateOperatorModule { }
