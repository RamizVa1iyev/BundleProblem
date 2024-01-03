using BundleProblem.ConsoleApp.Domains;
using BundleProblem.ConsoleApp.Persistence.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BundleProblem.ConsoleApp.Persistence.EntityFramework.Contexts;

public class BundleDbContext:DbContext
{
    public DbSet<Bundle> Bundles { get; set; }


    public BundleDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BundleEntityConfiguration());
    }
}
