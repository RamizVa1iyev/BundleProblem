using BundleProblem.ConsoleApp.Domains.AggregateModels.BundleAggregate;
using BundleProblem.ConsoleApp.Persistence.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BundleProblem.ConsoleApp.Persistence.EntityFramework.Contexts;

public class BundleDbContext : DbContext
{
    public DbSet<Bundle> Bundles { get; set; }
    public DbSet<BundleRelation> BundleRelations { get; set; }


    public BundleDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BundleEntityConfiguration());
        modelBuilder.ApplyConfiguration(new BundleRelationEntityConfiguration());
    }
}
