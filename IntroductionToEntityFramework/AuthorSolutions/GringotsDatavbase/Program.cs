using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GringotsDatavbase
{
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new GringotsContext();
            StringBuilder content = new StringBuilder();

            var firstLetters = context.WizzardDeposits.Where(deposit => deposit.DepositGroup == "Troll Chest")
                .Select(deposit => deposit.FirstName.Substring(0, 1))
                .Distinct()
                .OrderBy(s => s);

            foreach (var firstLetter in firstLetters)
            {
                content.AppendLine(firstLetter);
            }

            File.WriteAllText("temp.txt", content.ToString());
        }
    }
}
