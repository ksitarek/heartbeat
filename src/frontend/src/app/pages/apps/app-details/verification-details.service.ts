import { HttpClient } from '@angular/common/http';
import { computed, inject, Injectable, signal } from '@angular/core';
import { rxResource } from '@angular/core/rxjs-interop';
import { API_URL } from '../../../app.config';
import { ErrorHandlerService } from '../../../layout/services/error-handler.service';
import { VerificationStatus } from '../models/verification-status';

@Injectable({
  providedIn: 'root',
})
export class VerificationDetailsService {
  #apiUrl = inject(API_URL);

  #http = inject(HttpClient);

  #errorHandler = inject(ErrorHandlerService);

  #url = computed(() => {
    if (this.appId() === null) {
      return '';
    }
    return `${this.#apiUrl}/apps/${this.appId()}/verification-status`;
  });

  public readonly appId = signal<string | null>(null);

  readonly #details = rxResource({
    request: () => ({
      appId: this.appId(),
    }),

    loader: ({ request }) =>
      this.#http.get<VerificationStatus>(
        `${this.#apiUrl}/apps/${request.appId}/verification-status`
      ),
  });

  public readonly details = computed(() => {
    if (this.#details.error()) {
      this.#errorHandler.handleHttpError(this.#details.error());
      return null;
    }

    const value = this.#details.value();
    console.log('VerificationDetailsService.details', value);

    if (value === undefined) {
      return null;
    }

    return VerificationStatus.from(value!);
  });
}
