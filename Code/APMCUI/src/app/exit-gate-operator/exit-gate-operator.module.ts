import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ExitGateOperatorRoutingModule } from './exit-gate-operator-routing.module';
import { ExitGateOperatorComponent } from './exit-gate-operator.component';
import { ExitGateDashboardComponent } from './Component/exit-gate-dashboard/exit-gate-dashboard.component';
import { ExitGateComponent } from './Component/exit-gate/exit-gate.component';
import { TimepickerModule } from 'ngx-bootstrap/timepicker';
import {NgxMaterialTimepickerModule} from 'ngx-material-timepicker';
import { TypeaheadModule } from 'ngx-bootstrap/typeahead';

import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { VehicleListComponent } from './Component/vehicle-list/vehicle-list.component';


@NgModule({
  declarations: [ExitGateOperatorComponent, ExitGateDashboardComponent, ExitGateComponent, VehicleListComponent],
  imports: [
    CommonModule,
    ExitGateOperatorRoutingModule,
    MatInputModule,
    NgxMaterialTimepickerModule,
    FormsModule,
    TimepickerModule.forRoot(),
    TypeaheadModule
    
  ]
})
export class ExitGateOperatorModule { }
