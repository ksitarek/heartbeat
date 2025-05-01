import { inject, Injectable } from '@angular/core';
import { FormBuilder, FormControl, Validators } from '@angular/forms';
import { VerificationStrategy } from '../../models/verification-strategy';

@Injectable({
  providedIn: 'root',
})
export class VerificationConfigurationForm {
  #formBuilder = inject(FormBuilder);

  public readonly form = this.#formBuilder.group({
    verificationStrategy: new FormControl<VerificationStrategy | null>(null, [
      Validators.required,
    ]),
  });
}
