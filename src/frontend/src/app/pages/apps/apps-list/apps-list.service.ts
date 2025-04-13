import { HttpClient } from '@angular/common/http';
import { computed, inject, Injectable, signal } from '@angular/core';
import { rxResource } from '@angular/core/rxjs-interop';
import { catchError, map, Observable } from 'rxjs';
import { API_URL } from '../../../app.config';
import { ErrorHandlerService } from '../../../layout/services/error-handler.service';
import { AppListResponse } from './models/app-list-response';

@Injectable({
  providedIn: 'root',
})
export class AppsListService {
  #apiUrl = inject(API_URL);
  #http = inject(HttpClient);
  #errorHandler = inject(ErrorHandlerService);
  #reload = signal(1);

  #url = computed(
    () =>
      `${
        this.#apiUrl
      }/apps?currentPage=${this.currentPage()}&pageSize=${this.pageSize()}`
  );

  #resource = rxResource({
    request: () => ({
      reload: this.#reload(),
      url: this.#url(),
    }),
    defaultValue: AppListResponse.empty(),
    loader: ({ request }) => this.#fetch(request.url),
  });

  public readonly currentPage = signal(1);

  public readonly pageSize = signal(10);

  public readonly apps = computed(() => this.#resource.value().items ?? []);

  #fetch(url: string): Observable<AppListResponse> {
    return this.#http.get<AppListResponse>(url).pipe(
      map((response) => AppListResponse.from(response)),
      catchError((error) => this.#errorHandler.handleHttpError(error))
    );
  }

  public load() {
    this.#reload.update((value) => value * -1);
  }
}
