import { HttpClient } from '@angular/common/http';
import { computed, inject, Injectable, signal } from '@angular/core';
import { rxResource } from '@angular/core/rxjs-interop';
import { catchError, map, Observable, of } from 'rxjs';
import { API_URL } from '../../../app.config';
import { debouncedSignal } from '../../../layout/services/debounced-signal';
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
      reload: this.#dReload(),
      apiUrl: this.#apiUrl,
      url: `${this.#apiUrl}/apps`,
      currentPage: this.#dCurrentPage(),
      pageSize: this.#dPageSize(),
      sortBy: this.#dSortBy(),
      sortOrder: this.#dSortOrder(),
      search: this.#dSearch(),
    }),
    defaultValue: AppListResponse.empty(),
    loader: ({ request }) =>
      this.#fetch(
        request.url,
        request.currentPage,
        request.pageSize,
        request.sortBy,
        request.sortOrder,
        request.search
      ),
  });

  public readonly search = signal('');

  public readonly currentPage = signal<number>(-1);

  public readonly pageSize = signal<number>(-1);

  public readonly sortBy = signal('AppLabel');

  public readonly sortOrder = signal('asc');

  public readonly apps = computed(() => this.#resource.value().items ?? []);

  public readonly totalCount = computed(
    () => this.#resource.value().totalCount ?? 0
  );

  readonly #dSearch = debouncedSignal(this.search);
  readonly #dCurrentPage = debouncedSignal(this.currentPage);
  readonly #dPageSize = debouncedSignal(this.pageSize);
  readonly #dSortBy = debouncedSignal(this.sortBy);
  readonly #dSortOrder = debouncedSignal(this.sortOrder);
  readonly #dReload = debouncedSignal(this.#reload);

  #fetch(
    baseUrl: string,
    currentPage: number,
    pageSize: number,
    sortBy: string,
    sortOrder: string,
    search: string
  ): Observable<AppListResponse> {
    if (currentPage < 1 || pageSize < 1) {
      return of(AppListResponse.empty());
    }

    const url =
      `${baseUrl}?CurrentPage=${currentPage}` +
      `&PageSize=${pageSize}` +
      `&SortBy=${sortBy}` +
      `&SortOrder=${sortOrder}` +
      `&Search=${encodeURIComponent(search)}`;

    return this.#http.get<AppListResponse>(url).pipe(
      map((response) => AppListResponse.from(response)),
      catchError((error) => this.#errorHandler.handleHttpError(error))
    );
  }

  public load() {
    this.#reload.update((value) => value * -1);
  }
}
