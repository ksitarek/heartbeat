import { inject, Injectable } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { TranslateService } from '@ngx-translate/core';
import { toast } from 'ngx-sonner';
import { EMPTY, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ErrorHandlerService {
  #translateService: TranslateService = inject(TranslateService);

  readonly #errorHttpTitle = 'errorHandler.http.title';
  readonly #errorHttpDescription = 'errorHandler.http.description';
  readonly #errorHttpDismiss = 'errorHandler.http.dismiss';

  public handleHttpError(error: unknown): Observable<never> {
    console.error('An HTTP error occurred:', error);

    this.#translateService
      .stream([this.#errorHttpTitle, this.#errorHttpDescription, this.#errorHttpDismiss])
      .pipe(takeUntilDestroyed())
      .subscribe((translations) => {
        const title = translations[this.#errorHttpTitle];
        const description = translations[this.#errorHttpDescription];
        const dismiss = translations[this.#errorHttpDismiss];

        toast.error(title, {
          description: description,
          duration: 5000,
          action: {
            label: dismiss,
            onClick: () => {},
          },
        });
      });

    return EMPTY;
  }
}
