﻿using BundleProblem.ConsoleApp.Application.Helpers;
using BundleProblem.ConsoleApp.Domains.AggregateModels.BundleAggregate;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            Console.Write("Insert the count of bundles:");

            int countOfBundles = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Insert the names of bundles and stock amount(if not exist, insert zero)");

            List<Bundle> bundles = new List<Bundle>();//Select from DB if exist

            for (int i = 0; i < countOfBundles; i++)
            {
                string[] inputs = Console.ReadLine().Split();
                Bundle newBundle = new(i + 1, inputs[0], Int32.Parse(inputs[1]));

                bundles.Add(newBundle);
            }

            Console.WriteLine();
            Console.WriteLine("Inserted Bundles: ");
            foreach (var bundle in bundles)
            {
                Console.WriteLine("Id: {0}, Name: {1}, Stock: {2}", bundle.Id, bundle.Name, bundle.StockAmount);
            }

            Console.WriteLine();

            Console.WriteLine("Please insert the parentBundleId, childBundleId and the required quantity for creating parent bundle. (Enter -1 for continue)");//Use the select box if written with a web frontend

            int indexer = 1;
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "-1")
                    break;

                int[] values = Array.ConvertAll(input.Split(), Int32.Parse);

                var bundle = bundles.FirstOrDefault(b => b.Id == values[0]);
                BundleRelation bundleRelation = new BundleRelation(indexer, values[0], values[1], values[2]);
                bundle?.AddChildBundleRelation(bundleRelation);
                indexer++;
            }

            Console.WriteLine();
            Console.WriteLine("Insert the parent (P0) bundle ID that should be calculated the finished count.");

            int parentBundleId = Int32.Parse(Console.ReadLine());
            int maxFinishedBaseBundleCount = BundleHelper.CalculateFinishedCount(bundles, parentBundleId);

            Console.WriteLine("\nThe result is: {0}", maxFinishedBaseBundleCount);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception during process: Message = {0}", ex.Message);
        }
    }
}
