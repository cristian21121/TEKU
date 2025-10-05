import { Routes } from '@angular/router';

export const AUTH_ROUTES: Routes = [
  {
    path: 'supplier',
    loadComponent: () => import('./supplier.component/supplier.component').then(m => m.SupplierComponent)
  }
];