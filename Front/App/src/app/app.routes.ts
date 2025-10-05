import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: 'auth',
        loadChildren: () => import('./features/auth/routes').then(m => m.AUTH_ROUTES)
    },
    {
        path: 'shared',
        loadChildren: () => import('./shared/routes').then(m => m.AUTH_ROUTES)
    }
];
