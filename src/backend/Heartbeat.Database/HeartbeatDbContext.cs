using Heartbeat.Domain;
using Microsoft.EntityFrameworkCore;

namespace Heartbeat.Database;

public class HeartbeatDbContext : DbContext
{
    public DbSet<App> Apps { get; set; }

    public HeartbeatDbContext(DbContextOptions<HeartbeatDbContext> options)
        : base(options)
    {

    }
}
