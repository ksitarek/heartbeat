import { Component, input } from '@angular/core';
import { PageTitleComponent } from './page-title/page-title.component';

@Component({
  selector: 'hb-page',
  imports: [PageTitleComponent],
  templateUrl: './page.component.html',
  styleUrl: './page.component.scss',
})
export class PageComponent {
  readonly title = input.required<string>();
  readonly translateTitle = input.required<boolean>();
}
