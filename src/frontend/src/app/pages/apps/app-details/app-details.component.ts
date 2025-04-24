import { Component, computed, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PageComponent } from '../../../layout/components/page/page.component';
import { AppDetailsService } from './app-details.service';

@Component({
  selector: 'hb-app-details',
  imports: [PageComponent],
  templateUrl: './app-details.component.html',
  styleUrl: './app-details.component.scss',
})
export class AppDetailsComponent {
  readonly #appDetailsService = inject(AppDetailsService);
  readonly #activatedRoute = inject(ActivatedRoute);

  constructor() {
    this.#activatedRoute.params.subscribe((params) => {
      const appId = params['id'];
      if (appId) {
        this.#appDetailsService.id.set(appId);
      }
    });
  }

  public readonly appLabel = computed(() => {
    const details = this.#appDetailsService.details();
    return details ? details.label : '';
  });
}
