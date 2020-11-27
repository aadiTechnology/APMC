import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { EntryGateOperatorDashboardComponent } from './components/entry-gate-operator-dashboard/entry-gate-operator-dashboard.component';
import { IndentDetailsComponent } from './components/indent-details/indent-details.component';
import { IndentListRecordComponent } from './components/indent-list-record/indent-list-record.component';


import { EntryGateOperatorComponent } from "./entry-gate-operator.component";


const routes: Routes = [
  {
    path: '',
    component: EntryGateOperatorComponent,
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: 'dashboard', component: EntryGateOperatorDashboardComponent },
      { path: 'indentListRecord', component: IndentListRecordComponent },
      { path: 'indentDetail', component: IndentDetailsComponent },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class EntryGateOperatorRoutingModule {}
