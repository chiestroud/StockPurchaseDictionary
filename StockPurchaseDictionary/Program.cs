using System;
using System.Collections.Generic;

namespace StockPurchaseDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> stocks = new Dictionary<string, string>();
            stocks.Add("GM", "General Motors");
            stocks.Add("CAT", "Caterpillar");
            stocks.Add("TM", "Toyota Motor Corp");
            stocks.Add("GE", "General Electric");

            List<(string ticker, int shares, double price)> purchases = new List<(string, int, double)>();
            purchases.Add((ticker: "GE", shares: 150, price: 23.21));
            purchases.Add((ticker: "GE", shares: 32, price: 17.87));
            purchases.Add((ticker: "GE", shares: 80, price: 19.02));
            purchases.Add((ticker: "GM", shares: 30, price: 20.03));
            purchases.Add((ticker: "GM", shares: 60, price: 15.36));
            purchases.Add((ticker: "TM", shares: 70, price: 30.23));
            purchases.Add((ticker: "TM", shares: 50, price: 12.34));
            purchases.Add((ticker: "CAT", shares: 45, price: 18.76));
            purchases.Add((ticker: "CAT", shares: 44, price: 1.36));

            Dictionary<string, double> ownershipReport = new Dictionary<string, double>();
            
            foreach(var purchase in purchases)
            {
                var totalValue = purchase.shares * purchase.price;
                if (ownershipReport.ContainsKey(purchase.ticker))
                {
                    ownershipReport[purchase.ticker] += totalValue;
                }
                else
                {
                    ownershipReport.Add(purchase.ticker, totalValue);
                }
            }

            Console.WriteLine("-----Valuation for each stock-----");

            foreach (var ownership in ownershipReport)
            {
                foreach (var stock in stocks)
                {
                    if (ownership.Key == stock.Key)
                    {
                        Console.WriteLine($"{stock.Value}: {ownership.Value.ToString("F0")}");
                    }
                }
                
            }

        }
    }
}
