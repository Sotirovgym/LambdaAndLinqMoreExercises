using System;
using System.Collections.Generic;
using System.Linq;

class OrderedBankingSystem
{
    static void Main()
    {
        var banksData = new Dictionary<string, Dictionary<string, decimal>>();

        var input = Console.ReadLine();

        while (input != "end")
        {
            var tokens = input.Split(new[] { ' ', '-', '>' }, StringSplitOptions.RemoveEmptyEntries);

            var bankName = tokens[0];
            var bankAccount = tokens[1];
            var bankBalace = decimal.Parse(tokens[2]);

            if (!banksData.ContainsKey(bankName))
            {
                banksData[bankName] = new Dictionary<string, decimal>();
            }

            if (!banksData[bankName].ContainsKey(bankAccount))
            {
                banksData[bankName][bankAccount] = 0;
            }

            banksData[bankName][bankAccount] += bankBalace;

            input = Console.ReadLine();
        }

        var orderedBanksData = banksData
            .OrderByDescending(x => x.Value.Sum(account => account.Value))
            .ThenByDescending(bank => bank.Value.Max(account => account.Value));
            

        foreach (var bankData in orderedBanksData)
        {
            var bankName = bankData.Key;
            var bankAcount = bankData.Value;

            foreach (var kvp in bankAcount.OrderByDescending(balance => balance.Value))
            {
                var accountName = kvp.Key;
                var balance = kvp.Value;

                Console.WriteLine($"{accountName} -> {balance} ({bankName})");
            }
        }
    }
}

