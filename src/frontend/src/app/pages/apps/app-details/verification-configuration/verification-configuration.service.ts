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
    public id: string,
    public verificationStrategy: VerificationStrategy,
    public verificationToken: string
  ) {}

  public static empty() {
    return new VerificationConfiguration(
      '',
      VerificationStrategy.FileUpload,
      ''
    );
  }
}
