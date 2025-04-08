namespace Heartbeat.Domain.Verification;

public enum VerificationStrategy
{
    FileUpload,
    HttpHeader,
    DnsRecord,
}