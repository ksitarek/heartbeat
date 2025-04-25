import { httpResource } from '@angular/common/http';
import { computed, inject, Injectable, signal } from '@angular/core';
import { API_URL } from '../../../app.config';
import { ErrorHandlerService } from '../../../layout/services/error-handler.service';

@Injectable({
  providedIn: 'root',
})
export class AppDetailsService {
  #apiUrl = inject(API_URL);

  #errorHandler = inject(ErrorHandlerService);

  public readonly id = signal<number | null>(null);

  readonly #baseUrl = computed(() => `${this.#apiUrl}/apps/${this.id()}`);

  readonly #details = httpResource<AppDetails>(() => ({
    url: this.#baseUrl(),
    method: 'GET',
  }));

  public readonly details = computed(() => {
    if (this.id() === null) {
      return null;
    }

    if (this.#details.error()) {
      this.#errorHandler.handleHttpError(this.#details.error());
    }
    return this.#details.value();
  });
}

export class AppDetails {
  public constructor(public id: string, public label: string) {}
}
