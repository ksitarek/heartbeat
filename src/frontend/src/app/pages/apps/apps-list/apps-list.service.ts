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

  #resource = rxResource({
    request: () => ({
      reload: this.#reload(),
      apiUrl: this.#apiUrl,
      url: `${this.#apiUrl}/apps`,
      currentPage: this.currentPage(),
      pageSize: this.pageSize(),
      sortBy: this.sortBy(),
      sortOrder: this.sortOrder(),
    }),
    defaultValue: AppListResponse.empty(),
    loader: ({ request }) =>
      this.#fetch(
        request.url,
        request.currentPage,
        request.pageSize,
        request.sortBy,
        request.sortOrder
      ),
  });

  public readonly currentPage = signal(1);

  public readonly pageSize = signal(10);

  public readonly sortBy = signal('AppLabel');

  public readonly sortOrder = signal('asc');

  public readonly apps = computed(() => this.#resource.value().items ?? []);

  #fetch(
    baseUrl: string,
    currentPage: number,
    pageSize: number,
    sortBy: string,
    sortOrder: string
  ): Observable<AppListResponse> {
    const url =
      `${baseUrl}?CurrentPage=${currentPage}` +
      `&PageSize=${pageSize}` +
      `&SortBy=${sortBy}` +
      `&SortOrder=${sortOrder}`;

    return this.#http.get<AppListResponse>(url).pipe(
      map((response) => AppListResponse.from(response)),
      catchError((error) => this.#errorHandler.handleHttpError(error))
    );
  }

  public load() {
    this.#reload.update((value) => value * -1);
  }
}
