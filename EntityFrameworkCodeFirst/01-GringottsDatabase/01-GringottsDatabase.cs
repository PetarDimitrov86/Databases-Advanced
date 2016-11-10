using _01_GringottsDatabase.Models;
using System;

namespace _01_GringottsDatabase
{
    public class Program
    {
        static void Main(string[] args)
        {
            WizzardDeposit dumbledore = new WizzardDeposit
            {
                FirstName = "Albus",
                LastName = "Dumbledore",
                Age = 150,
                MagicWandCreator = "Antioch Peverell",
                MagicWandSize = 15,
                DepositStartDate = new DateTime(2016, 10, 20),
                DepositExpirationDate = new DateTime(2020, 10, 20),
                DepositAmount = 20000.24m,
                DepositCharge = 0.2m,
                IsDepositExpired = false
            };

            GringottsContext context = new GringottsContext();
            context.WizzardDeposits.Add(dumbledore);
            context.SaveChanges();
        }
    }
}