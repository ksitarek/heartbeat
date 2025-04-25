using Heartbeat.Domain.Verification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Heartbeat.Database.Configurations;

public class VerificationStatusConfiguration : IEntityTypeConfiguration<VerificationStatus>
{
    public void Configure(EntityTypeBuilder<VerificationStatus> builder)
    {
        builder.ToTable("verification_status");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.AppId).HasColumnName("app_id");

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(e => e.VerificationToken)
            .HasColumnName("verification_token");

        builder.Property(e => e.VerificationStrategy)
            .HasColumnName("verification_strategy")
            .HasConversion<string>()
            .IsRequired();

        builder.Property(e => e.WasVerificationSuccessful)
            .HasColumnName("was_verification_successful")
            .IsRequired();

        builder.Property(e => e.LastVerificationDateTime)
            .HasColumnName("last_verification_date_time")
            .IsRequired(false);
    }
}