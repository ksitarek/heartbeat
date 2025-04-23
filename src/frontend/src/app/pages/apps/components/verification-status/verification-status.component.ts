import { DatePipe, NgClass } from '@angular/common';
import { Component, computed, input } from '@angular/core';
import { NgIcon } from '@ng-icons/core';
import { TranslatePipe } from '@ngx-translate/core';
import { dateFormats } from '../../../../app.config';

@Component({
  selector: 'hb-verification-status',
  imports: [NgIcon, NgClass, TranslatePipe, DatePipe],
  templateUrl: './verification-status.component.html',
  styleUrl: './verification-status.component.scss',
})
export class VerificationStatusComponent {
  public readonly status = input.required<boolean>();
  public readonly dateTime = input.required<Date>();
  public readonly dateTimeFormat = dateFormats.dateTime;

  public readonly label = computed(() =>
    this.status()
      ? 'pages.applications.verification.verified'
      : 'pages.applications.verification.notVerified'
  );

  public readonly icon = computed(() =>
    this.status() ? 'lucideCheck' : 'lucideTriangleAlert'
  );

  public readonly classes = computed(() =>
    this.status() ? 'success' : 'danger'
  );
}
