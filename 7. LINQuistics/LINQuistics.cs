using System;
using System.Collections.Generic;
using System.Linq;

class LINQuistics
{
    static void Main()
    {
        var collection = new Dictionary<string, HashSet<string>>();

        var input = Console.ReadLine();

        while (input != "exit")
        {
            var tokens = input.Split(new[] { ' ', '.', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

            var number = 0;

            if (int.TryParse(tokens[0], out number))
            {
                var greaterCollection = collection.OrderByDescending(x => x.Value.Count()).Take(1);

                foreach (var kvp in greaterCollection)
                {
                    var orderedMethods = kvp.Value.OrderBy(x => x.Length).Take(number).ToList();

                    foreach (var method in orderedMethods)
                    {
                        Console.WriteLine($"* {method}");
                    }
                }
            }
            else if (tokens.Length == 1 && collection.ContainsKey(tokens[0]))
            {

                foreach (var kvp in collection)
                {
                    foreach (var method in kvp.Value.OrderByDescending(x => x.Length).ThenByDescending(x => x.Distinct().Count()))
                    {
                        Console.WriteLine($"* {method}");
                    }
                }

                input = Console.ReadLine();
                continue;
            }            

            if (tokens.Length > 1)
            {
                var collectionName = tokens[0];
                var methods = tokens.Skip(1);

                if (! collection.ContainsKey(collectionName))
                {
                    collection[collectionName] = new HashSet<string>();
                }

                foreach (var method in methods)
                {
                    collection[collectionName].Add(method);
                }

            }

            input = Console.ReadLine();
        }

        input = Console.ReadLine();

        var token = input.Split(' ');

        var orderCollections = collection
            .OrderByDescending(m => m.Value.Count)
            .ThenByDescending(m => m.Value.Min(name => name.Length))
            .ToDictionary(x => x.Key, x => x.Value);

        if (token[1] == "collection")
        {
            foreach (var kvp in orderCollections)
            {
                if (kvp.Value.Contains(token[0]))
                {
                    Console.WriteLine(kvp.Key);
                }              
            }
        }
        else if (token[1] == "all")
        {
            foreach (var kvp in orderCollections)
            {
                if (kvp.Value.Contains(token[0]))
                {
                    Console.WriteLine(kvp.Key);

                    foreach (var method in kvp.Value.OrderByDescending(x => x.Length))
                    {
                        Console.WriteLine($"* {method}");
                    }
                }
            }
        }

    }
}

