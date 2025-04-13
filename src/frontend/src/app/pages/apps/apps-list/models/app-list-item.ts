import { AvailabilityStatus } from '../../models/availability-status';

export class AppListItem {
  constructor(
    public appId: string,
    public appLabel: string,

    public lastCheckStatus: AvailabilityStatus,
    public lastCheckDateTime: Date,

    public lastVerificationStatus: boolean,
    public lastVerificationDateTime: Date
  ) {}

  static from(item: AppListItem): AppListItem {
    return new AppListItem(
      item.appId,
      item.appLabel,
      item.lastCheckStatus,
      new Date(item.lastCheckDateTime),
      item.lastVerificationStatus,
      new Date(item.lastVerificationDateTime)
    );
  }
}
