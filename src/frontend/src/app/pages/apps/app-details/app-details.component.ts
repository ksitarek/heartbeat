import { Component, computed, inject } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { ActivatedRoute } from '@angular/router';
import { TranslatePipe } from '@ngx-translate/core';
import { tap } from 'rxjs';
import { PageComponent } from '../../../layout/components/page/page.component';
import { H2Component } from '../../../layout/components/typography/h2/h2.component';
import { AppDetailsService } from './app-details.service';
import { VerificationConfigurationComponent } from './verification-configuration/verification-configuration.component';
import { VerificationConfiguration } from './verification-configuration/verification-configuration.service';

@Component({
  selector: 'hb-app-details',
  imports: [PageComponent, VerificationConfigurationComponent, TranslatePipe, H2Component],
  templateUrl: './app-details.component.html',
  styleUrl: './app-details.component.scss',
})
export class AppDetailsComponent {
  readonly #appDetailsService = inject(AppDetailsService);
  readonly #activatedRoute = inject(ActivatedRoute);

  constructor() {
    this.#activatedRoute.params
      .pipe(
        tap((params) => {
          const appId = params['id'];
          if (appId) {
            this.#appDetailsService.id.set(appId);
          }
        }),
        takeUntilDestroyed(),
      )
      .subscribe();
  }

  public readonly isLoaded = this.#appDetailsService.isLoaded;

  public readonly appId = computed(() => this.#appDetailsService.details()?.id ?? '');

  public readonly appLabel = computed(() => this.#appDetailsService.details()?.label ?? '');

  public readonly isVerificationConfigured = computed(() => !!this.verificationConfiguration().id);

  public readonly wasVerifiedAtLeastOnce = computed(() => !!this.#appDetailsService.details()?.lastVerificationDate);

  public readonly wasLastVerificationSuccessful = computed(() => {
    return this.isVerificationConfigured() && this.wasVerifiedAtLeastOnce() && this.#appDetailsService.details()?.lastVerificationStatus;
  });

  public readonly verificationConfiguration = computed(() => {
    if (this.#appDetailsService.details()?.verificationConfigurationId) {
      return new VerificationConfiguration(
        this.#appDetailsService.details()?.verificationConfigurationId ?? '',
        this.#appDetailsService.details()?.verificationStrategy!,
        this.#appDetailsService.details()?.verificationToken ?? '',
      );
    }

    return VerificationConfiguration.empty();
  });
}
