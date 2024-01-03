
namespace BundleProblem.ConsoleApp.Domains;

public class Bundle
{
    public int Id { get; set; }

    public string Name { get; private set; }

    public int? RequiredCountForParent { get; private set; }

    public int? StockAmount { get; private set; }

    public int? ParentBundleId { get; private set; }

    public virtual List<Bundle>? ChildBundles { get; private set; }

    public virtual Bundle? ParentBundle { get; private set; }
}
