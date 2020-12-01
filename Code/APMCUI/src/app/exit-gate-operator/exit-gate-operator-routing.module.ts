import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ExitGateDashboardComponent } from './Component/exit-gate-dashboard/exit-gate-dashboard.component';
import { ExitGateComponent } from './Component/exit-gate/exit-gate.component';
import { VehicleListComponent } from './Component/vehicle-list/vehicle-list.component';
import { ExitGateOperatorComponent } from './exit-gate-operator.component';

const routes: Routes = [
  { path: '', component: ExitGateOperatorComponent, 
children:[

  { path: '', redirectTo:'dashboard', pathMatch:'full' },
  { path: 'dashboard', component: ExitGateDashboardComponent},
  { path: 'exitGate', component: ExitGateComponent},
  { path:'VehicleList',component:VehicleListComponent}
],
},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExitGateOperatorRoutingModule { }
