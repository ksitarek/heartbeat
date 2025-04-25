import { VerificationStrategy } from './verification-strategy';

export class VerificationStatus {
  public constructor(
    public verificationStatusId: string,
    public verificationToken: string,
    public verificationStrategy: VerificationStrategy,
    public wasVerificationSuccessful: boolean
  ) {}

  public static from(data: VerificationStatus) {
    console.log('VerificationStatus.from', data);
    return new VerificationStatus(
      data.verificationStatusId,
      data.verificationToken,
      data.verificationStrategy,
      data.wasVerificationSuccessful
    );
  }
}
