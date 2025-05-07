using Heartbeat.Domain.Verification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Heartbeat.Database.Configurations;

public class VerificationConfigurationConfiguration : IEntityTypeConfiguration<VerificationConfiguration>
{
    public void Configure(EntityTypeBuilder<VerificationConfiguration> builder)
    {
        builder.ToTable("verification_configuration");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.AppId).HasColumnName("app_id");

        builder.Property(e => e.VerificationToken)
            .HasConversion<string>(
                c => c.ToString(),
                c => VerificationToken.FromString(c))
            .HasColumnName("verification_token");

        builder.Property(e => e.VerificationStrategy)
            .HasColumnName("verification_strategy")
            .HasConversion<string>()
            .IsRequired();

        builder.HasMany(e => e.VerificationHistory)
            .WithOne(v => v.VerificationConfiguration)
            .HasForeignKey(v => v.VerificationConfigurationId)
            .HasConstraintName("fk_verification_configuration_app")
            .OnDelete(DeleteBehavior.Cascade);
    }
}