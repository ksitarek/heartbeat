import {
  ApplicationConfig,
  InjectionToken,
  provideZoneChangeDetection,
} from '@angular/core';
import { provideRouter } from '@angular/router';

import { provideHttpClient } from '@angular/common/http';
import {
  provideIcons,
  provideNgIconsConfig,
  withExceptionLogger,
} from '@ng-icons/core';
import * as lucide from '@ng-icons/lucide';
import { environment } from '../environments/environment';
import { routes } from './app.routes';

export const API_URL = new InjectionToken<string>('apiUrl');

export const appConfig: ApplicationConfig = {
  providers: [
    provideIcons(lucide), // TODO this should be optimized as the bundle size is too big
    provideNgIconsConfig({}, withExceptionLogger()),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),

    provideHttpClient(),

    { provide: API_URL, useValue: environment.apiUrl },
  ],
};
