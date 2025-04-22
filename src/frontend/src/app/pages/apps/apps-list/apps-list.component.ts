import { Component, effect, inject, OnInit, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { TranslatePipe } from '@ngx-translate/core';
import { BrnTableModule } from '@spartan-ng/brain/table';
import { HlmButtonDirective } from '@spartan-ng/ui-button-helm';
import { HlmInputModule } from '@spartan-ng/ui-input-helm';
import { HlmTableModule } from '../../../../../libs/ui/ui-table-helm/src/index';
import { PageComponent } from '../../../layout/components/page/page.component';
import { SearchInputComponent } from '../../../layout/components/search-input/search-input.component';
import { AppCardComponent } from './app-card/app-card.component';
import { AppsListService } from './apps-list.service';
import { AppListItem } from './models/app-list-item';

@Component({
  imports: [
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

  public readonly currentPage = this.#appsListService.apps;
  public readonly totalCount = this.#appsListService.totalCount;
  public readonly search = this.#appsListService.search;

  public readonly items = signal<AppListItem[]>([]);

  public constructor() {
    effect(() => {
      this.items.update((items) => {
        if (this.#overrideOnNextLoad) {
          this.#overrideOnNextLoad = false;
          return this.#appsListService.apps();
        } else {
          return [...items, ...this.#appsListService.apps()];
        }
      });
    });

    effect(() => {
      this.search();

      this.#appsListService.currentPage.set(1);
      this.#appsListService.pageSize.set(4);

      this.#overrideOnNextLoad = true;
    });
  }

  public ngOnInit(): void {
    this.#appsListService.currentPage.set(1);
    this.#appsListService.pageSize.set(4);

    // this.#appsListService.load();
  }

  public loadMore() {
    this.#appsListService.currentPage.update((page) => page + 1);
  }
}
