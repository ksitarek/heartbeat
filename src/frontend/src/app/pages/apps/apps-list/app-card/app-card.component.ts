import { Component, computed, input } from '@angular/core';
import {
  HlmCardContentDirective,
  HlmCardDirective,
  HlmCardHeaderDirective,
  HlmCardTitleDirective,
} from '@spartan-ng/ui-card-helm';
import { CheckStatusComponent } from '../../check-status/check-status.component';
import { VerificationStatusComponent } from '../../verification-status/verification-status.component';
import { AppListItem } from '../models/app-list-item';

@Component({
  selector: 'hb-app-card',
  imports: [
    HlmCardDirective,
    HlmCardHeaderDirective,
    HlmCardTitleDirective,
    HlmCardContentDirective,
    VerificationStatusComponent,
    CheckStatusComponent,
  ],
  templateUrl: './app-card.component.html',
  styleUrl: './app-card.component.scss',
})
export class AppCardComponent {
  public readonly app = input.required<AppListItem>();

  public readonly id = computed(() => this.app().appId);

  public readonly label = computed(() => this.app().appLabel);

  public readonly lastCheckStatus = computed(() => this.app().lastCheckStatus);

  public readonly lastCheckDateTime = computed(
    () => this.app().lastCheckDateTime
  );

  public readonly lastVerificationStatus = computed(
    () => this.app().lastVerificationStatus
  );

  public readonly lastVerificationDateTime = computed(
    () => this.app().lastVerificationDateTime
  );

  public readonly classes = computed(() => {
    if (!this.lastVerificationStatus()) {
    }
  });
}
