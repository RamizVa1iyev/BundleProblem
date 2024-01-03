using BundleProblem.ConsoleApp.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BundleProblem.ConsoleApp.Persistence.EntityFramework.Configurations;

public class BundleEntityConfiguration : IEntityTypeConfiguration<Bundle>
{
    public void Configure(EntityTypeBuilder<Bundle> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x=>x.Name).IsRequired().HasMaxLength(255);
        builder.Property(x=>x.StockAmount).IsRequired(false);
        builder.Property(x => x.RequiredCountForParent).IsRequired(false);

        builder.HasOne(x => x.ParentBundle).WithMany(x => x.ChildBundles).HasForeignKey(x => x.ParentBundleId).HasPrincipalKey(x => x.Id);
    }
}
