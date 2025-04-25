import { Component, computed, effect, inject, input } from '@angular/core';
import { VerificationDetailsService } from '../verification-details.service';

@Component({
  selector: 'hb-verification-configuration',
  imports: [],
  templateUrl: './verification-configuration.component.html',
  styleUrl: './verification-configuration.component.scss',
})
export class VerificationConfigurationComponent {
  public appId = input.required<string>();

  public readonly hasVerificationStatus = computed(() => {
    console.log('hasVerificationStatus', this.#verificationDetails());
    return this.#verificationDetails() !== null;
  });

  public readonly wasVerificationSuccessful = computed(() => {
    return this.#verificationDetails()?.wasVerificationSuccessful ?? false;
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
