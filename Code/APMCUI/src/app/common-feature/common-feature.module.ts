import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CommonFeatureRoutingModule } from './common-feature-routing.module';
import { CommonFeatureComponent } from './common-feature.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { RouterModule } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatBadgeModule } from '@angular/material/badge';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatDividerModule } from '@angular/material/divider';
import { MatMenuModule } from '@angular/material/menu';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
@NgModule({
  declarations: [CommonFeatureComponent, LoginComponent, RegisterComponent],
  imports: [
    CommonModule,
    CommonFeatureRoutingModule,
    RouterModule,
    MatIconModule,
    MatToolbarModule,
    MatTooltipModule,
    MatSidenavModule,
    MatListModule,
    MatBadgeModule,
    MatProgressBarModule,
    MatButtonModule,
    MatCardModule,
    MatAutocompleteModule,
    MatDividerModule,
    MatMenuModule,
    MatFormFieldModule,
    FormsModule,
  ],
})
export class CommonFeatureModule {}
