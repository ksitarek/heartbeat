import { httpResource } from '@angular/common/http';
import { computed, inject, Injectable, signal } from '@angular/core';
import { API_URL } from '../../../app.config';
import { ErrorHandlerService } from '../../../layout/services/error-handler.service';
import { VerificationStrategy } from '../models/verification-strategy';

@Injectable({
  providedIn: 'root',
})
export class AppDetailsService {
  #apiUrl = inject(API_URL);

  #errorHandler = inject(ErrorHandlerService);

  public readonly id = signal<number | undefined>(undefined);

  readonly #details = httpResource<AppDetails>(() => `${this.#apiUrl}/apps/${this.id()}`);

  public readonly details = computed(() => {
    if (this.#details.error()) {
      this.#errorHandler.handleHttpError(this.#details.error());
    }
    return this.#details.value();
  });
}

export class AppDetails {
  public constructor(
    public id: string,
    public label: string,
    public lastVerificationDate: Date | null,
    public lastVerificationStatus: boolean | null,
    public verificationConfigurationId: string | null,
    public verificationStrategy: VerificationStrategy | null,
    public verificationToken: string | null,
  ) {}
}
