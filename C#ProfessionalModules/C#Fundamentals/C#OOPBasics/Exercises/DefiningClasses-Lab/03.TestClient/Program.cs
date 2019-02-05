using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, BankAccount> allAcounts = new Dictionary<int, BankAccount>();

        string input;

        while((input = Console.ReadLine()) != "End")
        {
            string[] commandArguments = input.Split(' ');

            if(commandArguments[0] == "Create")
            {
                int newId = int.Parse(commandArguments[1]);

                if(allAcounts.ContainsKey(newId))
                {
                    Console.WriteLine("Account already exists");
                }
                else
                {
                    BankAccount newAccount = new BankAccount();

                    newAccount.Id = newId;
                    newAccount.Balance = 0;

                    allAcounts.Add(newId, newAccount);
                }
            }
            else if(commandArguments[0] == "Deposit")
            {
                int newId = int.Parse(commandArguments[1]);
                decimal newAmount = decimal.Parse(commandArguments[2]);

                if(allAcounts.ContainsKey(newId))
                {
                    allAcounts[newId].Deposit(newAmount);
                }
                else
                {
                    Console.WriteLine("Account does not exist");
                }
            }
            else if (commandArguments[0] == "Withdraw")
            {
                int newId = int.Parse(commandArguments[1]);
                decimal newAmount = decimal.Parse(commandArguments[2]);

                if (allAcounts.ContainsKey(newId))
                {
                    if(allAcounts[newId].Balance >= newAmount)
                    {
                        allAcounts[newId].Withdraw(newAmount);
                    }
                    else
                    {
                        Console.WriteLine("Insufficient balance");
                    }
                }
                else
                {
                    Console.WriteLine("Account does not exist");
                }
            }
            else if (commandArguments[0] == "Print")
            {
                int newId = int.Parse(commandArguments[1]);

                if (allAcounts.ContainsKey(newId))
                {
                    Console.WriteLine(allAcounts[newId].ToString());
                }
                else
                {
                    Console.WriteLine("Account does not exist");
                }
            }
        }
    }
}

