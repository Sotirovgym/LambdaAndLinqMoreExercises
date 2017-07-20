using System;
using System.Collections.Generic;
using System.Linq;

class ArrayData
{
    static void Main()
    {
        var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
        var command = Console.ReadLine();

        var average = list.Average();

        var newList = list.Where(n => n >= average).ToList();

        if (command == "Min")
        {
            Console.WriteLine(newList.Min());
        }
        else if (command == "Max")
        {
            Console.WriteLine(newList.Max());
        }
        else
        {
            var orederd = newList.OrderBy(n => n).ToList();

            Console.WriteLine(string.Join(" ", orederd));
        }
        
    }
}

