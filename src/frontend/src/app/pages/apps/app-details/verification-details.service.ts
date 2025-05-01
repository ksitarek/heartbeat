import { HttpClient } from '@angular/common/http';
import { effect, inject, Injectable, signal } from '@angular/core';
import { toSignal } from '@angular/core/rxjs-interop';
import {
  BehaviorSubject,
  catchError,
  combineLatest,
  filter,
  map,
  Observable,
  of,
  switchMap,
} from 'rxjs';
import { API_URL } from '../../../app.config';
import { ErrorHandlerService } from '../../../layout/services/error-handler.service';
import { VerificationStatus } from '../models/verification-status';

@Injectable({
  providedIn: 'root',
})
export class VerificationDetailsService {
  readonly #apiUrl = inject(API_URL);
  readonly #http = inject(HttpClient);
  readonly #errorHandler = inject(ErrorHandlerService);

  readonly #reload$ = new BehaviorSubject(null);
  readonly #appId$ = new BehaviorSubject<string | undefined>(undefined);
  readonly #details$: Observable<VerificationStatus | null> = combineLatest([
    this.#reload$,
    this.#appId$,
  ]).pipe(
    filter(([_, appId]) => !!appId),
    map(([_, appId]) => appId),
    map((appId) => this.#getUrl(appId!)),
    switchMap((url) => this.#http.get<VerificationStatus>(url)),
    map((response) => {
      return VerificationStatus.from(response);
    }),
    catchError((error) => {
      this.#errorHandler.handleHttpError(error);
      return of(null);
    })
  );

  public readonly appId = signal<string | undefined>(undefined);
  public readonly details = toSignal(this.#details$);

  public constructor() {
    effect(() => {
      if (!!this.appId()) {
        this.#appId$.next(this.appId());
      }
    });
  }

  #getUrl(appId: string) {
    return `${this.#apiUrl}/apps/${appId}/verification-status`;
  }

  public load() {
    this.#reload$.next(null);
  }
}
