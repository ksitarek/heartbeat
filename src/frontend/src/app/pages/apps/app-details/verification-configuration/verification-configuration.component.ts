import { Component, input } from '@angular/core';
import { TranslatePipe } from '@ngx-translate/core';

@Component({
  selector: 'hb-verification-configuration',
  imports: [TranslatePipe],
  templateUrl: './verification-configuration.component.html',
  styleUrl: './verification-configuration.component.scss',
})
export class VerificationConfigurationComponent {
  public appId = input.required<string>();
}
