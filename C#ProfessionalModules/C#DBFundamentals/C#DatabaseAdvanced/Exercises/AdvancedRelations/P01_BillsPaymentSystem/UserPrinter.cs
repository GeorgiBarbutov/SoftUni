using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Linq;

namespace P01_BillsPaymentSystem
{
    public class UserPrinter
    {
        public void Print(int id, BillsPaymentSystemContext context)
        {
            User user = FindUser(id, context);

            if (user == null)
            {
                Console.WriteLine($"User with id {id} not found!");
            }
            else
            {
                Console.WriteLine($"User: {user.FirstName} {user.LastName}");
                Console.WriteLine($"BankAccounts:");

                if (user.PaymentMethods.Where(pm => pm.BankAccountId != null).Count() == 0)
                {
                    Console.WriteLine("-- none --");
                }
                else
                {
                    foreach (var bankAccountPayments in user.PaymentMethods.Where(pm => pm.BankAccountId != null))
                    {
                        var account = bankAccountPayments.BankAccount;

                        Console.WriteLine($"-- ID: {account.BankAccountId}");
                        Console.WriteLine($"--- Balance: {account.Balance:f2}");
                        Console.WriteLine($"--- Bank: {account.BankName}");
                        Console.WriteLine($"--- SWIFT: {account.SWIFTCode}");
                    }
                }

                Console.WriteLine($"CreditCards:");
                if (user.PaymentMethods.Where(pm => pm.CreditCardId != null).Count() == 0)
                {
                    Console.WriteLine("-- none --");
                }
                else
                {
                    foreach (var CreditCardPayments in user.PaymentMethods.Where(pm => pm.CreditCardId != null))
                    {
                        var creditCard = CreditCardPayments.CreditCard;

                        Console.WriteLine($"-- ID: {creditCard.CreditCardId}");
                        Console.WriteLine($"--- Limit: {creditCard.Limit:f2}");
                        Console.WriteLine($"--- Money Owed: {creditCard.MoneyOwed:f2}");
                        Console.WriteLine($"--- Limit Left: {creditCard.LimitLeft:f2}");
                        Console.WriteLine($"--- Expiration Date: {creditCard.ExpirationDate.Year}/{creditCard.ExpirationDate.Month}");
                    }
                }
            }
        }

        private static User FindUser(int id, BillsPaymentSystemContext context)
        {
            return context.Users.Include(u => u.PaymentMethods)
                                                     .ThenInclude(pm => pm.BankAccount)
                                                     .Include(u => u.PaymentMethods)
                                                     .ThenInclude(pm => pm.CreditCard)
                                                     .FirstOrDefault(u => u.UserId == id);
        }
    }
}
