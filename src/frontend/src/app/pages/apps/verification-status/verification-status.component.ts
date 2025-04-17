import { NgClass } from '@angular/common';
import { Component, computed, input } from '@angular/core';
import { NgIcon } from '@ng-icons/core';
import { TranslatePipe } from '@ngx-translate/core';

@Component({
  selector: 'hb-verification-status',
  imports: [NgIcon, NgClass, TranslatePipe],
  templateUrl: './verification-status.component.html',
  styleUrl: './verification-status.component.scss',
})
export class VerificationStatusComponent {
  public readonly status = input.required<boolean>();

  public readonly label = computed(() =>
    this.status()
      ? 'pages.applications.verification.verified'
      : 'pages.applications.verification.notVerified'
  );

  public readonly icon = computed(() =>
    this.status() ? 'lucideCheck' : 'lucideTriangleAlert'
  );

  public readonly classes = computed(() =>
    this.status()
      ? 'text-lime-600 dark:text-lime-500'
      : 'text-rose-600 dark:text-rose-500'
  );
}
