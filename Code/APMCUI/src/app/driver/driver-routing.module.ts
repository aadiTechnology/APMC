import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DriverDashboardComponent } from './components/driver-dashboard/driver-dashboard.component';

import { DriverComponent } from './driver.component';

const routes: Routes = [
  { path: '', component: DriverComponent,
  children: [
        { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
        { path: 'dashboard', component: DriverDashboardComponent },
        
      ],
   }
   ];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DriverRoutingModule { }
