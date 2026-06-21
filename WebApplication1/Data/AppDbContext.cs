using Microsoft.EntityFrameworkCore;

namespace WinApplication;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Mechanic> Mechanics { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Visit> Visits { get; set; }
    public DbSet<VisitService> VisitServices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VisitService>().HasKey(vs => new { vs.VisitId, vs.ServiceId });
    }
}