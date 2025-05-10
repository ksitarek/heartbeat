import { Component, computed, model } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { VerificationStrategy } from '../../models/verification-strategy';
import { StrategyPickerComponent } from './strategy-picker/strategy-picker.component';
import { TokenFieldComponent } from './token-field/token-field.component';
import { VerificationConfiguration } from './verification-configuration.service';

@Component({
  selector: 'hb-verification-configuration',
  imports: [ReactiveFormsModule, StrategyPickerComponent, TokenFieldComponent],
  templateUrl: './verification-configuration.component.html',
  styleUrl: './verification-configuration.component.scss',
})
export class VerificationConfigurationComponent {
  public verificationConfiguration = model.required<VerificationConfiguration>();

  readonly token = computed(() => this.verificationConfiguration()?.verificationToken ?? '');

  readonly strategy = computed(() => this.verificationConfiguration()?.verificationStrategy ?? '');

  public updateVerificationStrategy(strategy: VerificationStrategy): void {
    this.verificationConfiguration.update((v) => ({
      ...v,
      verificationStrategy: strategy,
    }));
  }
}
