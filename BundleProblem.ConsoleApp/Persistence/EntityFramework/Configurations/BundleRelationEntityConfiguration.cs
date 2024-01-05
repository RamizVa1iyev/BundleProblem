using BundleProblem.ConsoleApp.Domains.AggregateModels.BundleAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BundleProblem.ConsoleApp.Persistence.EntityFramework.Configurations;

public class BundleRelationEntityConfiguration : IEntityTypeConfiguration<BundleRelation>
{
    public void Configure(EntityTypeBuilder<BundleRelation> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasOne(r => r.ParentBundle).WithMany(b => b.ChildBundleRelations).HasForeignKey(r => r.ParentBundleId).HasPrincipalKey(b => b.Id);
        builder.HasOne(r => r.ChildBundle).WithMany().HasForeignKey(r => r.ChildBundleId).HasPrincipalKey(b => b.Id);
    }
}
