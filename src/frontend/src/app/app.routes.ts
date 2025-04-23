import { Routes } from '@angular/router';
import { appsRoutes } from './pages/apps/apps.routes';

export const routes: Routes = [
  ...appsRoutes,

  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'apps',
  },
];
