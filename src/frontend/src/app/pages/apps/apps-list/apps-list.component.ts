import { AsyncPipe } from '@angular/common';
import { Component, effect, inject, OnInit, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { TranslatePipe } from '@ngx-translate/core';
import { BrnTableModule } from '@spartan-ng/brain/table';
import { HlmButtonDirective } from '@spartan-ng/ui-button-helm';
import { HlmInputModule } from '@spartan-ng/ui-input-helm';
import { map, tap } from 'rxjs';
import { HlmTableModule } from '../../../../../libs/ui/ui-table-helm/src/index';
import { PageComponent } from '../../../layout/components/page/page.component';
import { SearchInputComponent } from '../../../layout/components/search-input/search-input.component';
import { AppCardComponent } from './app-card/app-card.component';
import { AppsListService } from './apps-list.service';
import { AppListItem } from './models/app-list-item';

@Component({
  imports: [
    AsyncPipe,
    PageComponent,
    BrnTableModule,
    HlmTableModule,
    AppCardComponent,
    HlmButtonDirective,
    TranslatePipe,
    FormsModule,
    HlmInputModule,
    SearchInputComponent,
  ],
  templateUrl: './apps-list.component.html',
  styleUrl: './apps-list.component.scss',
})
export class AppsListComponent implements OnInit {
  #appsListService = inject(AppsListService);
  #overrideOnNextLoad = true;
  #currentItems: AppListItem[] = [];
  #totalCount: number = 0;

  readonly #currentPage = signal(1);

  readonly defaultPageSize = 4;

  readonly defaultPage = 1;

  public readonly search = signal<string | null>(null);

  public readonly items$ = this.#appsListService.list$.pipe(
    tap((response) => {
      if (this.#overrideOnNextLoad) {
        this.#overrideOnNextLoad = false;
        this.#currentItems = response.items;
      } else {
        this.#currentItems = [...this.#currentItems, ...response.items];
      }

      this.#totalCount = response.totalCount;
    }),
    map(() => {
      return this.#currentItems;
    })
  );

  public constructor() {
    effect(() => {
      this.#overrideOnNextLoad = true;

      this.#appsListService.search = this.search();
      this.#appsListService.currentPage = this.defaultPage;

      this.#appsListService.reload();
    });

    effect(() => {
      this.#appsListService.currentPage = this.#currentPage();
      this.#appsListService.reload();
    });
  }

  public ngOnInit(): void {
    this.#appsListService.currentPage = this.defaultPage;
    this.#appsListService.pageSize = this.defaultPageSize;

    this.#appsListService.reload();
  }

  public loadMore() {
    this.#currentPage.update((page) => page + 1);
  }

  public get loadMoreVisible() {
    return this.#currentItems.length < this.#totalCount;
  }
}
