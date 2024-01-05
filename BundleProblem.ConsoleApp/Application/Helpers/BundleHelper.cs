using BundleProblem.ConsoleApp.Domains.AggregateModels.BundleAggregate;

namespace BundleProblem.ConsoleApp.Application.Helpers
{
    public static class BundleHelper
    {
        public static int CalculateFinishedCount(List<Bundle> bundles, Bundle baseBundle)
        {
            int finishedCount = Int32.MaxValue;

            foreach (var childRelation in baseBundle.ChildBundleRelations)
            {
                int maxFinishedChildBundleCount = CalculateChildFinishedCount(bundles, childRelation);
                if (finishedCount > maxFinishedChildBundleCount)
                    finishedCount = maxFinishedChildBundleCount;
            }

            if (baseBundle.ChildBundleRelations.Count == 0)
                finishedCount = 0;


            int totalStockValue = baseBundle.StockAmount + finishedCount;

            return totalStockValue;
        }

        public static int CalculateChildFinishedCount(List<Bundle> bundles, BundleRelation bundleRelation)
        {

            int finishedCount = Int32.MaxValue;

            foreach (var childRelation in bundleRelation.ChildBundle.ChildBundleRelations)
            {
                int maxFinishedChildBundleCount = CalculateChildFinishedCount(bundles, childRelation);

                if (finishedCount > maxFinishedChildBundleCount)
                    finishedCount = maxFinishedChildBundleCount;
            }

            if (bundleRelation.ChildBundle.ChildBundleRelations.Count == 0)
                finishedCount = 0;


            int totalStockValue = bundleRelation.ChildBundle.StockAmount + finishedCount;

            return totalStockValue / (bundleRelation.RequiredQuantity);
        }
    }
}
