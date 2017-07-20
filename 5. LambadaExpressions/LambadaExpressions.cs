using System;
using System.Collections.Generic;
using System.Linq;

class LambadaExpressions
{
    static void Main()
    {
        var expression = new Dictionary<string, Dictionary<string, string>>();

        var input = Console.ReadLine();

        while (input != "lambada")
        {
            var tokens = input.Split(new[] { ' ', '=', '>', '.' }, StringSplitOptions.RemoveEmptyEntries);

            if (tokens[0] != "dance")
            {
                var selector = tokens[0];
                var selectorObject = tokens[1];
                var property = tokens[2];

                if (!expression.ContainsKey(selector))
                {
                    expression[selector] = new Dictionary<string, string>();
                }

                expression[selector][selectorObject] = property;
            }
            else
            {
                expression = expression
                    .ToDictionary(selectorData => selectorData.Key, selectorData => selectorData.Value
                .ToDictionary(selectObjectData => selectObjectData.Key, selectObjectData => selectObjectData.Key + "." +  selectObjectData.Value));                  
            }

            input = Console.ReadLine();
        }

        foreach (var selectorData in expression)
        {
            Console.Write($"{selectorData.Key} => ");

            foreach (var kvp in selectorData.Value)
            {
                Console.WriteLine($"{kvp.Key + "."}{kvp.Value}");
            }
        }
    }
}

