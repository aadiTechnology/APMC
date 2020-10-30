import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './home/components/login/login.component';
import { RegisterComponent } from './home/components/register/register.component';
import { LoginLayoutComponent } from './shared/layouts/login-layout/login-layout.component';
import { MainLayoutComponent } from './shared/layouts/main-layout/main-layout.component';

const routes: Routes = [
  {
    path: '',
    component: LoginLayoutComponent,
    data: {
      title: 'login layout',
      prelod: true,
    },
    children: [
      {
        path: '',
        redirectTo: 'login',
        pathMatch: 'full',
      },
      {
        path: 'login',
        component: LoginComponent,
        data: {
          title: 'Login',
          prelod: true,
        },
      },
      {
        path: 'register',
        component: RegisterComponent,
        data: {
          title: 'Register',
          prelod: true,
        },
      },
    ],
  },
  {
    path: '',
    component: MainLayoutComponent,
    data: {},
    children: [
      {
        path: 'merchant',
        loadChildren: () =>
          import('./merchant/merchant.module').then((m) => m.MerchantModule),
      },
      {
        path: 'home',
        loadChildren: () =>
          import('./home/home.module').then((m) => m.HomePageModule),
      },
    ],
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules }),
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
