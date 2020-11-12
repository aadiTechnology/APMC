import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainLayoutComponent } from './layouts/main-layout/main-layout.component';
import { LoginLayoutComponent } from './layouts/login-layout/login-layout.component';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FooterComponent } from './layouts/footer/footer.component';
import { NavbarComponent } from './layouts/navbar/navbar.component';
import { SidebarComponent } from './layouts/sidebar/sidebar.component';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

@NgModule({
  declarations: [
    MainLayoutComponent,
    LoginLayoutComponent,
    FooterComponent,
    NavbarComponent,
    SidebarComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    HttpClientModule,
    CollapseModule.forRoot(),
    ToastrModule.forRoot(),
    NgxSpinnerModule,
    BsDropdownModule.forRoot(),
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class SharedModule {}
