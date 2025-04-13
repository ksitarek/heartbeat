import { Injectable } from '@angular/core';
import {
  MissingTranslationHandler,
  MissingTranslationHandlerParams,
} from '@ngx-translate/core';

@Injectable({
  providedIn: 'root',
})
export class DebugMissingTranslationService
  implements MissingTranslationHandler
{
  handle(params: MissingTranslationHandlerParams) {
    console.warn('Missing translation for key:', params.key);
    return params.key;
  }
}
