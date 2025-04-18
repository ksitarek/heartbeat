import { AppListItem } from './app-list-item';

export class AppListResponse {
  constructor(public items: AppListItem[], public totalCount: number) {}

  static empty(): AppListResponse {
    return new AppListResponse([], 0);
  }

  static from(item: AppListResponse): AppListResponse {
    return new AppListResponse(
      item.items.map((i) => AppListItem.from(i)),
      item.totalCount
    );
  }
}
