import { Component, inject, input } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { NgIcon } from '@ng-icons/core';
import { TranslatePipe } from '@ngx-translate/core';
import { HlmRadioGroupModule } from '@spartan-ng/ui-radiogroup-helm';
import { VerificationConfigurationForm } from './verification-configuration.form';

@Component({
  selector: 'hb-verification-configuration',
  imports: [TranslatePipe, ReactiveFormsModule, HlmRadioGroupModule, NgIcon],
  templateUrl: './verification-configuration.component.html',
  styleUrl: './verification-configuration.component.scss',
})
export class VerificationConfigurationComponent {
  public appId = input.required<string>();
  public readonly form = inject(VerificationConfigurationForm).form;
}
