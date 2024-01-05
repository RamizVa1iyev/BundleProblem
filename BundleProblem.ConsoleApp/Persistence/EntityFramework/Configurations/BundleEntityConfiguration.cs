using BundleProblem.ConsoleApp.Domains.AggregateModels.BundleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BundleProblem.ConsoleApp.Persistence.EntityFramework.Configurations;

public class BundleEntityConfiguration : IEntityTypeConfiguration<Bundle>
{
    public void Configure(EntityTypeBuilder<Bundle> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name).IsRequired().HasMaxLength(255);

        builder.HasMany(b=>b.ChildBundleRelations).WithOne(r=>r.ParentBundle).HasForeignKey(r=>r.ParentBundleId).HasPrincipalKey(b=>b.Id);
    }
}
