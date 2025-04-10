using Heartbeat.Domain;
using Heartbeat.Domain.Checks;
using Heartbeat.Domain.Verification;
using Microsoft.EntityFrameworkCore;

namespace Heartbeat.Database;

public class HeartbeatDbContext : DbContext
{
    public DbSet<App> Apps { get; set; }
    public DbSet<VerificationStatus> VerificationStatuses { get; set; }
    public DbSet<Check> Checks { get; set; }
    public DbSet<CheckStatusLog> CheckStatusLogs { get; set; }
    public DbSet<CheckResponse> CheckResponses { get; set; }

    public HeartbeatDbContext(DbContextOptions<HeartbeatDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(HeartbeatDbContext).Assembly);
    }
}
