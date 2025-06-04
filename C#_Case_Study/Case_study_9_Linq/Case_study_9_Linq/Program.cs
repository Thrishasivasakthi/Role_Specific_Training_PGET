using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCodeTemplate
{
    internal class Problem1
    {
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();
            //query_1
            var result = products.Where(p => p.ProCategory == "FMCG").ToList();
            foreach (var item in result)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }
            //query_2
            var grainProducts = products.Where(p => p.ProCategory == "Grain").ToList();
            foreach (var item in grainProducts)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }
            //query_3
            var sortByProCode = products.OrderBy(p => p.ProCode).ToList();
            foreach (var item in grainProducts)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }
            //query_4
            var sortByProCategory = products.OrderBy(p => p.ProCategory).ToList();
            foreach (var item in grainProducts)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }
            //query_5
            var sortByProMrp = products.OrderBy(p => p.ProMrp).ToList();
            foreach (var item in sortByProMrp)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }
            //query_6
            var sortByDescProMrp = products.OrderByDescending(p => p.ProMrp).ToList();
            foreach (var item in sortByDescProMrp)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }
            //query_7
            var grpByProCategory = products.GroupBy(p => p.ProCategory).ToList();
            foreach (var group in grpByProCategory)
            {
                Console.WriteLine($"Category: {group.Key}");
                foreach (var item in group)
                {
                    Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
                }
            }
            //query_8
            var grpByProMrp = products.GroupBy(p => p.ProMrp).ToList();
            foreach (var group in grpByProMrp)
            {
                Console.WriteLine($"Price: {group.Key}");
                foreach (var item in group)
                {
                    Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
                }
            }
            //query_9
            var highestPriceInFmcg = products.Where(p => p.ProCategory == "FMCG").Max(p => p.ProMrp);
            Console.WriteLine($"Highest Price in FMCG: {highestPriceInFmcg}");
            //query_10
            var countTotalPro = products.Count();
            Console.WriteLine($"Total Products: {countTotalPro}");
            //query_11
             var countTotalProFmcg = products.Count(p => p.ProCategory == "FMCG");
            Console.WriteLine($"Total Products in FMCG: {countTotalProFmcg}");
            //query_12
            var maxProMrp = products.Max(p => p.ProMrp);
            Console.WriteLine($"Maximum Product MRP: {maxProMrp}");
            //query_13
            var minProMrp = products.Min(p => p.ProMrp);
            Console.WriteLine($"Minimum Product MRP: {minProMrp}");
            //query_14
            var proBelowProPrice_30 = products.All(p => p.ProMrp < 30);
            if (proBelowProPrice_30)
            {
                Console.WriteLine("All products are below 30");
            }
            else
            {
                Console.WriteLine("Not all products are below 30");
            }
            //query_15
            var proBelowProPrice_30Any = products.Any(p => p.ProMrp < 30);
            if (proBelowProPrice_30Any)
            {
                Console.WriteLine("There are products below 30");
            }
            else
            {
                Console.WriteLine("No products are below 30");
            }


            Console.ReadLine();
        }
    }
}