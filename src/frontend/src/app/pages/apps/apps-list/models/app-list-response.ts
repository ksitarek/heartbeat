import { AppListItem } from './app-list-item';

export class AppListResponse {
  constructor(public items: AppListItem[]) {}

  static empty(): AppListResponse {
    return new AppListResponse([]);
  }

  static from(item: AppListResponse): AppListResponse {
    return new AppListResponse(item.items.map((i) => AppListItem.from(i)));
  }
}
