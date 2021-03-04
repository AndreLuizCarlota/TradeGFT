using System;
using TradeGFT.Models;
using TradeGFT.Interfaces;
using System.Collections.Generic;

namespace TradeGFT
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ITrade> trades = new List<ITrade>()
            {
                new Trade(2000000.00, "Private"),
                new Trade(400000.00, "Public"),
                new Trade(500000.00, "Public"),
                new Trade(3000000.00, "Public"),
                new Trade(526.99, "Private"),
                new Trade(999.66, "Public"),
            };

            List<string> portfolio = new List<string>();

            trades.ForEach(trade => portfolio.Add((trade as Trade)?.Category));

            Console.WriteLine(string.Join(", ", portfolio));
        }
    }
}
