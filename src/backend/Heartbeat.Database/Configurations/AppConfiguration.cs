using Heartbeat.Domain;

namespace Heartbeat.Database.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AppConfiguration : IEntityTypeConfiguration<App>
{
    public void Configure(EntityTypeBuilder<App> builder)
    {
        builder.ToTable("app");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd(); // Let PostgreSQL generate UUID

        builder.Property(e => e.Label)
            .HasColumnName("label")
            .IsRequired();

        builder.HasMany(e => e.Checks)
            .WithOne(c => c.App)
            .HasForeignKey(c => c.AppId)
            .HasConstraintName("fk_check_app")
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.VerificationConfiguration)
            .WithOne(c => c.App)
            .HasConstraintName("fk_verification_configuration_app")
            .OnDelete(DeleteBehavior.Cascade);
    }
}