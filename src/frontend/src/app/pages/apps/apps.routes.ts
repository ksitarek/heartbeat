import { Routes } from '@angular/router';

export const appsRoutes: Routes = [
  {
    path: 'apps',
    loadComponent: () =>
      import('./apps-list/apps-list.component').then(
        (m) => m.AppsListComponent
      ),
  },
  {
    path: 'apps/:id',
    loadComponent: () =>
      import('./app-details/app-details.component').then(
        (m) => m.AppDetailsComponent
      ),
  },
];
