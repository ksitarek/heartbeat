import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import {
  provideIcons,
  provideNgIconsConfig,
  withExceptionLogger,
} from '@ng-icons/core';
import * as lucide from '@ng-icons/lucide';
import { routes } from './app.routes';

export const appConfig: ApplicationConfig = {
  providers: [
    provideIcons(lucide),
    provideNgIconsConfig({}, withExceptionLogger()),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
  ],
};
