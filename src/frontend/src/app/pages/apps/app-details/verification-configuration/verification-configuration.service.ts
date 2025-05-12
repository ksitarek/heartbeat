import { Injectable } from '@angular/core';
import { VerificationStrategy } from '../../models/verification-strategy';

@Injectable({
  providedIn: 'root',
})
export class VerificationConfigurationService {
  constructor() {}
}

export class VerificationConfiguration {
  public constructor(
    public id: string | undefined,
    public verificationStrategy: VerificationStrategy | undefined,
    public verificationToken: string | undefined,
  ) {}

  public static empty() {
    return new VerificationConfiguration(undefined, undefined, undefined);
  }
}
