internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Insert base bundle name P(0): ");

        string baseBundleName = Console.ReadLine();

        BundleDto baseBundle = new(baseBundleName);

        List<BundleDto> bundles = new List<BundleDto>();

        var parentBundle = baseBundle;
        do
        {
            Console.Write("Insert count of child bundles of {0}: ", parentBundle.Name);
            int childBundlesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < childBundlesCount; i++)
            {
                Console.Write("Insert: count of child bundle for creating parent bundle, name of bundle and if exist stock number of bundle (2 Pedal 60) or (2 Wheel): ");
                var inputs = Console.ReadLine().Split();
                if (inputs.Length == 3)
                {
                    parentBundle.AddChildBundle(new BundleDto(inputs[1], int.Parse(inputs[0]), int.Parse(inputs[2])));
                }
                else if (inputs.Length == 2)
                {
                    parentBundle.AddChildBundle(new BundleDto(inputs[1], int.Parse(inputs[0])));
                }
            }

            Console.Write("If there is child bundles of inserted bundles please insert parent bundle name (Wheel) else insert -1 : ");

            string bundleName = Console.ReadLine();

            parentBundle = Search(baseBundle, bundleName);

        } while (parentBundle != null);



        int maxFinishedBaseBundleCount = CalculateFinishedCount(baseBundle);

        Console.WriteLine("\nThe result is: {0}", maxFinishedBaseBundleCount);

    }
    public static int CalculateFinishedCount(BundleDto baseBundle)
    {
        int minValue = -1;

        foreach (BundleDto childBundle in baseBundle.ChildBundles)
        {
            int maxFinishedChildBundleCount = CalculateFinishedCount(childBundle);
            if (minValue > maxFinishedChildBundleCount || minValue == -1)
                minValue = maxFinishedChildBundleCount;
        }

        int totalStockValue = (minValue == -1 ? 0 : minValue) + (baseBundle.StockAmount ?? 0);

        return totalStockValue / (baseBundle.RequiredCountForParent ?? 1);
    }

    public static BundleDto? Search(BundleDto baseBundle, string name)
    {
        if (name == "-1")
            return null;

        if (baseBundle.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
        {
            return baseBundle;
        }

        foreach (var childBundle in baseBundle.ChildBundles)
        {
            var foundBundle = Search(childBundle, name);
            if (foundBundle != null)
                return foundBundle;
        }

        return null;
    }
}

public class BundleDto
{
    public BundleDto()
    {
        ChildBundles = new List<BundleDto>();
    }
    public BundleDto(string name) : this()
    {
        Name = name;
    }

    public BundleDto(string name, int requiredCountForParent) : this(name)
    {
        RequiredCountForParent = requiredCountForParent;
    }


    public BundleDto(string name, int requiredCountForParent, int stockAmount) : this(name, requiredCountForParent)
    {
        StockAmount = stockAmount;
    }

    public string Name { get; private set; }

    public int? RequiredCountForParent { get; private set; }

    public int? StockAmount { get; private set; }

    public List<BundleDto>? ChildBundles { get; private set; }

    public void AddChildBundle(BundleDto child)
    {
        ChildBundles.Add(child);
    }
}