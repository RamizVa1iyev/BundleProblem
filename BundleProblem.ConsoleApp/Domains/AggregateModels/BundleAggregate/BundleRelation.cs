
namespace BundleProblem.ConsoleApp.Domains.AggregateModels.BundleAggregate;

public class BundleRelation
{
    public BundleRelation(int id, int parentBundleId, int childBundleId, int requiredQuantity)
    {
        if (requiredQuantity <= 0)
            throw new ArgumentException(nameof(requiredQuantity));

        Id = id;
        ParentBundleId = parentBundleId;
        ChildBundleId = childBundleId;
        RequiredQuantity = requiredQuantity;
    }

    public BundleRelation(int id, int parentBundleId, int childBundleId, int requiredQuantity, Bundle parentBundle, Bundle childBundle) : this(id, parentBundleId, childBundleId, requiredQuantity)
    {
        ParentBundle = parentBundle;
        ChildBundle = childBundle;
    }

    public int Id { get; private set; }

    public int ParentBundleId { get; private set; }

    public int ChildBundleId { get; private set; }

    public int RequiredQuantity { get; private set; }

    public Bundle ParentBundle { get; private set; }

    public Bundle ChildBundle { get; private set; }
}
