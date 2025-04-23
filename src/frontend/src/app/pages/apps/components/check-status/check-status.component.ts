import { DatePipe, NgClass } from '@angular/common';
import { Component, computed, input } from '@angular/core';
import { NgIcon } from '@ng-icons/core';
import { TranslatePipe } from '@ngx-translate/core';
import { dateFormats } from '../../../../app.config';
import { AvailabilityStatus } from '../../models/availability-status';

@Component({
  selector: 'hb-check-status',
  imports: [NgClass, TranslatePipe, NgIcon, DatePipe],
  templateUrl: './check-status.component.html',
  styleUrl: './check-status.component.scss',
})
export class CheckStatusComponent {
  public readonly status = input.required<AvailabilityStatus>();
  public readonly dateTime = input.required<Date>();
  public readonly dateTimeFormat = dateFormats.dateTime;

  public readonly label = computed(() => {
    switch (this.status()) {
      case AvailabilityStatus.Up:
        return 'pages.applications.statusCheck.up';
      case AvailabilityStatus.Down:
        return 'pages.applications.statusCheck.down';
      case AvailabilityStatus.Unknown:
      default:
        return 'pages.applications.statusCheck.unknown';
    }
  });

  public readonly icon = computed(() => {
    switch (this.status()) {
      case AvailabilityStatus.Up:
        return 'lucideCheck';
      case AvailabilityStatus.Down:
        return 'lucideTriangleAlert';
      case AvailabilityStatus.Unknown:
      default:
        return 'lucideShieldQuestion';
    }
  });

  public readonly classes = computed(() => {
    switch (this.status()) {
      case AvailabilityStatus.Up:
        return 'success';
      case AvailabilityStatus.Down:
        return 'danger';
      case AvailabilityStatus.Unknown:
      default:
        return 'warning';
    }
  });
}
