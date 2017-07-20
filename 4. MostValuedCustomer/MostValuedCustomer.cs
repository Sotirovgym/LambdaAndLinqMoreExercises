using System;
using System.Collections.Generic;
using System.Linq;

class MostValuedCustomer
{
    static void Main()
    {
        var productsAndPrice = new Dictionary<string, decimal>();

        var customers = new Dictionary<string, List<string>>();

        var input = Console.ReadLine();

        var isShopIsOpen = false;

        while (input != "Print")
        {
            if (input == "Shop is open")
            {
                isShopIsOpen = true;
                input = Console.ReadLine();
            }

            if (input == "Discount")
            {
                var topThree = productsAndPrice
                    .OrderByDescending(x => x.Value)
                    .Take(3)
                    .ToDictionary(x => x.Key, x => x.Value * 0.90m);

                foreach (var item in topThree)
                {
                    productsAndPrice[item.Key] = item.Value;
                }
            }

            else if (isShopIsOpen == false)
            {
                var tokens = input.Split(' ');
                var product = tokens[0];
                var price = decimal.Parse(tokens[1]);

                productsAndPrice[product] = price;
            }
            else if (isShopIsOpen == true)
            {
                var tokens = input.Split(new[] { ' ', ':', ',' }, StringSplitOptions.RemoveEmptyEntries);
                var customer = tokens[0];
                var products = tokens.Skip(1).ToList();

                if (!customers.ContainsKey(customer))
                {
                    customers[customer] = new List<string>();
                }

                customers[customer].AddRange(products);
            }

            input = Console.ReadLine();
        }

        var bestBuyer = new Dictionary<string, decimal>();

        foreach (var kvp in customers)
        {
            decimal total = 0;
            var buyer = kvp.Key;

            var boughtProducts = kvp.Value.ToList();

            foreach (var product in boughtProducts)
            {
                total += productsAndPrice[product];
            }

            bestBuyer.Add(buyer, total);
        }

        foreach (var kvp in bestBuyer.OrderByDescending(x => x.Value).Take(1))
        {
            var name = kvp.Key;

            Console.WriteLine($"Biggest spender: {name}");
            Console.WriteLine($"^Products bought:");

            foreach (var customer in customers)
            {
                if (customer.Key == name)
                {
                    foreach (var product in customer.Value.Distinct())
                    {
                        Console.WriteLine($"^^^{product}: {productsAndPrice[product]:f2}");
                    }
                }                
            }

            Console.WriteLine($"Total: {kvp.Value:f2}");
        }
        
    }
}

