using BundleProblem.ConsoleApp.Domains.AggregateModels.BundleAggregate;

namespace BundleProblem.ConsoleApp.Application.Helpers
{
    public static class BundleHelper
    {
        public static int CalculateFinishedCount(List<Bundle> bundles, int parentBundleId)
        {
            var parentBundle = bundles.FirstOrDefault(b => b.Id == parentBundleId);


            int finishedCount = Int32.MaxValue;


            foreach (var childRelation in parentBundle.ChildBundleRelations)
            {
                int maxFinishedChildBundleCount = CalculateChildFinishedCount(bundles, childRelation);
                if (finishedCount > maxFinishedChildBundleCount)
                    finishedCount = maxFinishedChildBundleCount;
            }

            if (parentBundle.ChildBundleRelations.Count == 0)
                finishedCount = 0;


            int totalStockValue = parentBundle.StockAmount + finishedCount;

            return totalStockValue;
        }

        public static int CalculateChildFinishedCount(List<Bundle> bundles, BundleRelation bundleRelation)
        {
            var parentBundle = bundles.FirstOrDefault(b => b.Id == bundleRelation.ChildBundleId);


            int finishedCount = Int32.MaxValue;

            foreach (var childRelation in parentBundle.ChildBundleRelations)
            {
                int maxFinishedChildBundleCount = CalculateChildFinishedCount(bundles, childRelation);

                if (finishedCount > maxFinishedChildBundleCount)
                    finishedCount = maxFinishedChildBundleCount;
            }

            if (parentBundle.ChildBundleRelations.Count == 0)
                finishedCount = 0;


            int totalStockValue = parentBundle.StockAmount + finishedCount;

            return totalStockValue / (bundleRelation.RequiredQuantity);
        }
    }
}
