import { Component, input } from '@angular/core';
import { TranslatePipe } from '@ngx-translate/core';

@Component({
  selector: 'hb-page-title',
  imports: [TranslatePipe],
  templateUrl: './page-title.component.html',
  styleUrl: './page-title.component.scss',
})
export class PageTitleComponent {
  readonly title = input.required<string>();
  readonly translateTitle = input.required<boolean>();
}
