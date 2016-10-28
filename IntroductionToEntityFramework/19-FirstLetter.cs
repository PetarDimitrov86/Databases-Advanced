using System;
using System.Linq;
using Gringotts;

class FirstLetter
{
    static void Main(string[] args)
    {
        using (var context = new GringottsContext())
        {
            var deposits = context.WizzardDeposits
                .Where(w => w.DepositGroup == "Troll Chest")
                .OrderBy(w => w.FirstName)
                .Select(t => new
                {
                    FirstLetter = t.FirstName.Substring(0, 1)
                });

            foreach (var wizzardDeposit in deposits.Distinct())
            {
                Console.WriteLine($"{wizzardDeposit.FirstLetter}");
            }
        }
    }
}