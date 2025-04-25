import { DatePipe } from '@angular/common';
import { Component, computed, effect, inject, input } from '@angular/core';
import { TranslatePipe } from '@ngx-translate/core';
import { dateFormats } from '../../../../app.config';
import { VerificationConfigurationComponent } from '../verification-configuration/verification-configuration.component';
import { VerificationDetailsService } from '../verification-details.service';

@Component({
  selector: 'hb-verification-status',
  imports: [TranslatePipe, DatePipe, VerificationConfigurationComponent],
  templateUrl: './verification-status.component.html',
  styleUrl: './verification-status.component.scss',
})
export class VerificationStatusComponent {
  public appId = input.required<string>();
  public readonly dateFormat = dateFormats.dateTime;

  public readonly hasVerificationStatus = computed(() => {
    console.log('hasVerificationStatus', this.#verificationDetails());
    return this.#verificationDetails() !== null;
  });

  public readonly wasVerificationSuccessful = computed(() => {
    return this.#verificationDetails()?.wasVerificationSuccessful ?? false;
  });

  public readonly lastVerificationDateTime = computed(() => {
    return this.#verificationDetails()?.lastVerificationDateTime ?? null;
  });

  readonly #verificationDetailsService = inject(VerificationDetailsService);
  readonly #verificationDetails = this.#verificationDetailsService.details;

  constructor() {
    effect(() => {
      if (!!this.appId()) {
        this.#verificationDetailsService.appId.set(this.appId());
      }
    });
  }
}
