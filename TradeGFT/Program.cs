using System;
using TradeGFT.Enums;
using TradeGFT.Models;
using TradeGFT.Services;
using TradeGFT.Interfaces;
using TradeGFT.Repositories;
using System.Collections.Generic;

namespace TradeGFT
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoryService categoryService = new CategoryService(MockCategories());

            List<ITrade> trades = new List<ITrade>()
            {
                new Trade(2000000.00, "Private"),
                new Trade(400000.00, "Public"),
                new Trade(500000.00, "Public"),
                new Trade(3000000.00, "Public"),
                new Trade(526.99, "Private"),
                new Trade(999.66, "Public")
            };

            List<string> portfolio = new List<string>();

            foreach (var trade in trades)
                portfolio.Add(categoryService.GetTradeCategory(trade).ToString());

            Console.WriteLine(string.Join(", ", portfolio));
        }

        private static List<Category> MockCategories()
        {
            CategoryRepository categoryService = new CategoryRepository();

            // LOWRISKPULIC
            categoryService.Add(new Category(Rules.LOWRISK, 0, 1000, "Public"));
            // MEDIUMRISKPUBLIC
            categoryService.Add(new Category(Rules.MEDIUMRISK, 1000, double.MaxValue, "Public"));
            // HIGHRISKPRIVATE
            categoryService.Add(new Category(Rules.HIGHRISK, 1000, double.MaxValue, "Private"));

            return categoryService.Categories;
        }
    }
}
