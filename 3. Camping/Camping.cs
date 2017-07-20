using System;
using System.Collections.Generic;
using System.Linq;

class Camping
{
    static void Main()
    {
        var campingInfo = new Dictionary<string, Dictionary<string, int>>();

        var input = Console.ReadLine();

        var campersAndNights = new Dictionary<string, int>();

        while (input != "end")
        {
            var tokens = input.Split(' ');

            var personName = tokens[0];
            var camperModel = tokens[1];
            var nigths = int.Parse(tokens[2]);

            if (!campingInfo.ContainsKey(personName))
            {
                campingInfo[personName] = new Dictionary<string, int>();
            }
           
            campingInfo[personName][camperModel] = nigths;

            campersAndNights = campingInfo[personName];

            input = Console.ReadLine();
        }

        var orderedNamesByCampersCount = campingInfo
            .OrderByDescending(c => c.Value.Count())
            .ThenBy(p => p.Key.Length)
            .ToDictionary(x => x.Key, x => x.Value);

        foreach (var personAndCamper in orderedNamesByCampersCount)
        {
            var count = 0;
            var nightsCount = 0;

            Console.WriteLine($"{personAndCamper.Key}: {personAndCamper.Value.Count}");

            foreach (var camper in personAndCamper.Value)
            {
                count++;
                nightsCount += camper.Value;

                Console.WriteLine($"***{camper.Key}");

                if (count == personAndCamper.Value.Count)
                {
                    Console.WriteLine($"Total stay: {nightsCount} nights");
                }
            }
        }
    }
}

