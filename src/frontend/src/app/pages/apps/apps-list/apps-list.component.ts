import { Component, effect, inject, OnInit, signal } from '@angular/core';
import { TranslatePipe } from '@ngx-translate/core';
import { BrnTableModule } from '@spartan-ng/brain/table';
import { HlmButtonDirective } from '@spartan-ng/ui-button-helm';
import { HlmTableModule } from '../../../../../libs/ui/ui-table-helm/src/index';
import { PageComponent } from '../../../layout/components/page/page.component';
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
  ],
  templateUrl: './apps-list.component.html',
  styleUrl: './apps-list.component.scss',
})
export class AppsListComponent implements OnInit {
  #appsListService = inject(AppsListService);

  public readonly currentPage = this.#appsListService.apps;
  public readonly totalCount = this.#appsListService.totalCount;

  public readonly items = signal<AppListItem[]>([]);

  public constructor() {
    effect(() => {
      this.items.update((items) => {
        return [...items, ...this.#appsListService.apps()];
      });
    });
  }

  public ngOnInit(): void {
    this.#appsListService.currentPage.set(1);
    this.#appsListService.pageSize.set(4);

    this.#appsListService.load();
  }

  public loadMore() {
    this.#appsListService.currentPage.update((page) => page + 1);
  }
}
