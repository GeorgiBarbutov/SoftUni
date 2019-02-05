using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Linq;

namespace P01_BillsPaymentSystem
{
    public static class BillsPayer
    {
        public static void PayBills(int userId, decimal amount, BillsPaymentSystemContext context)
        {
            GetTotalAvailableFunds(userId, context, out User user, out decimal totalFundsAvailable);

            if (amount > totalFundsAvailable)
            {
                Console.WriteLine("Insufficient funds!");
            }
            else
            {
                PayWithBankAccounts(user, ref amount);

                PayWithCreditCards(user, ref amount);
            }

            context.SaveChanges();
        }

        private static void PayWithCreditCards(User user, ref decimal amount)
        {
            var creditCards = user.PaymentMethods
                                   .Select(pm => pm.CreditCard).ToArray();

            if (creditCards[0] == null)
            {
                return;
            }

            var orderedCreditCards = creditCards.OrderBy(cc => cc.CreditCardId)
                                       .ToArray();

            for (int i = 0; i < orderedCreditCards.Length; i++)
            {
                if (orderedCreditCards[i].LimitLeft > amount)
                {
                    orderedCreditCards[i].Withdraw(amount);
                    return;
                }

                amount -= orderedCreditCards[i].LimitLeft;
                orderedCreditCards[i].Withdraw(orderedCreditCards[i].LimitLeft);
            }
        }

        private static void PayWithBankAccounts(User user, ref decimal amount)
        {
            var bankAccounts = user.PaymentMethods
                                   .Select(pm => pm.BankAccount).ToArray();

            if (bankAccounts[0] == null)
            {
                return;
            }

            var orderedBankAccounts = bankAccounts.OrderBy(ba => ba.BankAccountId)
                                       .ToArray();

            for (int i = 0; i < orderedBankAccounts.Length; i++)
            {
                if (orderedBankAccounts[i].Balance > amount)
                {
                    orderedBankAccounts[i].Withdraw(amount);
                    amount = 0;
                    return;
                }

                amount -= orderedBankAccounts[i].Balance;
                orderedBankAccounts[i].Withdraw(orderedBankAccounts[i].Balance);
            }
        }

        private static void GetTotalAvailableFunds(int userId, BillsPaymentSystemContext context, out User user, out decimal totalFundsAvailable)
        {
            user = context.Users
                          .Include(u => u.PaymentMethods)
                          .ThenInclude(pm => pm.BankAccount)
                          .Include(u => u.PaymentMethods)
                          .ThenInclude(pm => pm.CreditCard)
                          .ToArray()
                          .FirstOrDefault(u => u.UserId == userId);
            decimal bankAccountsBalance = user.PaymentMethods
                                              .Where(pm => pm.BankAccount != null)
                                              .Sum(pm => pm.BankAccount.Balance);
            decimal creditCardsLimitLeft = user.PaymentMethods
                                               .Where(pm => pm.CreditCard != null)
                                               .Sum(pm => pm.CreditCard.LimitLeft);

            totalFundsAvailable = bankAccountsBalance + creditCardsLimitLeft;
        }
    }
}
