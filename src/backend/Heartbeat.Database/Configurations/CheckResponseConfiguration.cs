using Heartbeat.Domain.Checks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Heartbeat.Database.Configurations;

public class CheckResponseConfiguration : IEntityTypeConfiguration<CheckResponse>
{
    public void Configure(EntityTypeBuilder<CheckResponse> builder)
    {
        builder.ToTable("check_response");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.ResponseCollected)
            .HasColumnName("response_collected")
            .IsRequired();

        builder.Property(e => e.Response)
            .HasColumnName("response");
    }
}