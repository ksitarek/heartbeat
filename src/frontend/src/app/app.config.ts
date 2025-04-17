import {
  ApplicationConfig,
  InjectionToken,
  provideZoneChangeDetection,
} from '@angular/core';
import { provideRouter } from '@angular/router';
import { DebugMissingTranslationService } from './layout/services/debug-missing-translation.service';

import { HttpClient, provideHttpClient } from '@angular/common/http';
import {
  provideIcons,
  provideNgIconsConfig,
  withExceptionLogger,
} from '@ng-icons/core';
import * as lucide from '@ng-icons/lucide';
import {
  MissingTranslationHandler,
  provideTranslateService,
  TranslateLoader,
} from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { environment } from '../environments/environment';
import { routes } from './app.routes';

export const API_URL = new InjectionToken<string>('apiUrl');

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http, './i18n/', '.json');
}

export const appConfig: ApplicationConfig = {
  providers: [
    provideIcons(lucide), // TODO this should be optimized as the bundle size is too big
    provideNgIconsConfig({}, withExceptionLogger()),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),

    provideHttpClient(),

    provideTranslateService({
      defaultLanguage: 'en',
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [HttpClient],
      },
      missingTranslationHandler: {
        provide: MissingTranslationHandler,
        useClass: DebugMissingTranslationService,
      },
    }),

    { provide: API_URL, useValue: environment.apiUrl },
  ],
};

export const dateFormats = {
  dateTime: 'yyyy-MM-dd HH:mm:ss',
};
