import { Component, input } from '@angular/core';

@Component({
  selector: 'hb-page-title',
  imports: [],
  templateUrl: './page-title.component.html',
  styleUrl: './page-title.component.scss',
})
export class PageTitleComponent {
  readonly title = input.required<string>();
}
