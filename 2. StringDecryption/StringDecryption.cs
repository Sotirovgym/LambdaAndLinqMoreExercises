using System;
using System.Collections.Generic;
using System.Linq;

class StringDecryption
{
    static void Main()
    {
        var mn = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        var number = Console.ReadLine().Split(' ').Select(int.Parse).ToList();        

        var capitalLatinLetter = number.Where(num => num >= 65 && num <= 90).ToList();
        var filteredNumbers = capitalLatinLetter.Skip(mn[0]).Take(mn[1]).ToList();

        var ascii = filteredNumbers.Select(n => (char)n).ToList();

        Console.WriteLine(string.Join("", ascii));
    }
}

