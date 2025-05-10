import { Component, input } from '@angular/core';
import { NgIcon } from '@ng-icons/core';
import { HlmButtonDirective } from '@spartan-ng/ui-button-helm';
import { ClickToCopyDirective } from '../../../../../directives/click-to-copy.directive';

@Component({
  selector: 'hb-token-field',
  imports: [HlmButtonDirective, NgIcon, ClickToCopyDirective],
  templateUrl: './token-field.component.html',
  styleUrl: './token-field.component.scss',
})
export class TokenFieldComponent {
  public token = input.required<string>();
}
