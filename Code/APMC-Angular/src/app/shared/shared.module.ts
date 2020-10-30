import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginLayoutComponent } from './layouts/login-layout/login-layout.component';
import { IonicModule } from '@ionic/angular';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [LoginLayoutComponent],
  imports: [IonicModule, FormsModule, CommonModule],
})
export class SharedModule {}
