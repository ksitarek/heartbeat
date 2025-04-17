import { NgClass } from '@angular/common';
import { Component, computed, input } from '@angular/core';
import { NgIcon } from '@ng-icons/core';
import { TranslatePipe } from '@ngx-translate/core';
import { AvailabilityStatus } from '../models/availability-status';

@Component({
  selector: 'hb-check-status',
  imports: [NgClass, TranslatePipe, NgIcon],
  templateUrl: './check-status.component.html',
  styleUrl: './check-status.component.scss',
})
export class CheckStatusComponent {
  public readonly status = input.required<AvailabilityStatus>();

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
        return 'text-lime-600 dark:text-lime-500';
      case AvailabilityStatus.Down:
        return 'text-rose-600 dark:text-rose-500';
      case AvailabilityStatus.Unknown:
      default:
        return 'text-amber-600 dark:text-amber-500';
    }
  });
}
