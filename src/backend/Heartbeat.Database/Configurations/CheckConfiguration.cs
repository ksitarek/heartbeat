using Heartbeat.Domain.Checks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Heartbeat.Database.Configurations;

public class CheckConfiguration : IEntityTypeConfiguration<Check>
{
    public void Configure(EntityTypeBuilder<Check> builder)
    {
        builder.ToTable("check");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.AppId).HasColumnName("app_id");

        builder.Property(e => e.Label).HasColumnName("label").IsRequired();
        builder.Property(e => e.Interval).HasColumnName("interval").IsRequired();
        builder.Property(e => e.Timeout).HasColumnName("timeout").IsRequired();
        builder.Property(e => e.Retries).HasColumnName("retries").IsRequired();
        builder.Property(e => e.Url).HasColumnName("url").IsRequired();
        builder.Property(e => e.Port).HasColumnName("port").IsRequired();
        builder.Property(e => e.ExpectedResponse).HasColumnName("expected_response");
        builder.Property(e => e.CollectResponse).HasColumnName("collect_response").IsRequired();

        builder.HasMany(e => e.CheckStatusLogs)
            .WithOne(l => l.Check)
            .HasForeignKey(l => l.CheckId)
            .HasConstraintName("fk_check_status_log_check")
            .OnDelete(DeleteBehavior.Cascade);
    }
}