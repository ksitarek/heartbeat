using Heartbeat.Domain.Checks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Heartbeat.Database.Configurations;

public class CheckStatusLogConfiguration : IEntityTypeConfiguration<CheckStatusLog>
{
    public void Configure(EntityTypeBuilder<CheckStatusLog> builder)
    {
        builder.ToTable("check_status_log");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.CheckId).HasColumnName("check_id");

        builder.Property(e => e.Status)
            .HasColumnName("status")
            .HasConversion<string>()
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.Property(e => e.CheckResponseId).HasColumnName("check_response_id");

        builder.HasOne(e => e.CheckResponse)
            .WithMany()
            .HasForeignKey(e => e.CheckResponseId)
            .HasConstraintName("fk_check_status_log_response");
    }
}