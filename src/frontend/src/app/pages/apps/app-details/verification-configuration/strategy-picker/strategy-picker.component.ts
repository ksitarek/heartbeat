import { Component, effect, model } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgIcon } from '@ng-icons/core';
import { HlmRadioComponent, HlmRadioGroupComponent } from '@spartan-ng/ui-radiogroup-helm';
import { VerificationStrategy } from '../../../models/verification-strategy';

@Component({
  selector: 'hb-strategy-picker',
  imports: [FormsModule, HlmRadioComponent, HlmRadioGroupComponent, NgIcon],
  templateUrl: './strategy-picker.component.html',
  styleUrl: './strategy-picker.component.scss',
})
export class StrategyPickerComponent {
  public readonly verificationStrategy = model<VerificationStrategy>();

  public readonly strategies = [
    {
      value: VerificationStrategy.DnsRecord,
      label: 'DNS Record',
      icon: 'lucideServer',
    },
    {
      value: VerificationStrategy.FileUpload,
      label: 'File Upload',
      icon: 'lucideFileUp',
    },
    {
      value: VerificationStrategy.HttpHeader,
      label: 'HTTP Header',
      icon: 'lucideGlobe',
    },
  ];

  public constructor() {
    effect(() => {
      console.log('Selected strategy:', this.verificationStrategy());
    });
  }

  public setStrategy(strategy: VerificationStrategy): void {
    this.verificationStrategy.set(strategy);
  }
}
