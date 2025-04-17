import { DatePipe } from '@angular/common';
import {
  Component,
  computed,
  inject,
  OnInit,
  TrackByFunction,
} from '@angular/core';
import { TranslatePipe } from '@ngx-translate/core';
import { BrnTableModule, useBrnColumnManager } from '@spartan-ng/brain/table';
import { HlmTableModule } from '../../../../../libs/ui/ui-table-helm/src/index';
import { dateFormats } from '../../../app.config';
import { DataTableColumnHeaderComponent } from '../../../layout/components/data-table/data-table-column-header/data-table-column-header.component';
import { PageComponent } from '../../../layout/components/page/page.component';
import { CheckStatusComponent } from '../check-status/check-status.component';
import { VerificationStatusComponent } from '../verification-status/verification-status.component';
import { AvailabilityStatus } from './../models/availability-status';
import { AppsListService } from './apps-list.service';
import { AppListItem } from './models/app-list-item';

@Component({
  imports: [
    PageComponent,
    TranslatePipe,
    DataTableColumnHeaderComponent,
    BrnTableModule,
    HlmTableModule,
    DatePipe,
    CheckStatusComponent,
    VerificationStatusComponent,
  ],
  templateUrl: './apps-list.component.html',
  styleUrl: './apps-list.component.scss',
})
export class AppsListComponent implements OnInit {
  #appsListService = inject(AppsListService);

  public readonly items = this.#appsListService.apps;

  public readonly dateFormats = dateFormats;

  public AvailabilityStatus = AvailabilityStatus;

  protected readonly columnManager = useBrnColumnManager({
    appLabel: { visible: true, label: 'App Label' },
    lastCheckStatus: { visible: true, label: 'Last Check Status' },
    lastCheckDateTime: {
      visible: true,
      label: 'Last Check Date Time',
    },
    lastVerificationStatus: {
      visible: true,
      label: 'Last Verification Status',
    },
    lastVerificationDateTime: {
      visible: true,
      label: 'Last Verification Date Time',
    },
  });

  protected readonly trackBy: TrackByFunction<AppListItem> = (
    _: number,
    p: AppListItem
  ) => p.appId;

  protected readonly dataTableColumns = computed(() => [
    ...this.columnManager.displayedColumns(),
  ]);

  public ngOnInit(): void {
    this.#appsListService.load();
  }

  public get sortBy() {
    return this.#appsListService.sortBy;
  }

  public get sortOrder() {
    return this.#appsListService.sortOrder;
  }
}
