namespace BundleProblem.ConsoleApp.Domains.AggregateModels.BundleAggregate;

public class Bundle
{
    public Bundle(int id, string name)
    {
        if (String.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        _bundleRelations = new List<BundleRelation>();
        Id = id;
        Name = name;
    }

    public Bundle(int id, string name, int stockAmount) : this(id, name)
    {
        StockAmount = stockAmount;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public int StockAmount { get; private set; }

    private readonly List<BundleRelation> _bundleRelations;
    public IReadOnlyCollection<BundleRelation> ChildBundleRelations => _bundleRelations;


    public void AddChildBundleRelation(BundleRelation relation)
    {
        _bundleRelations.Add(relation);
    }
}
