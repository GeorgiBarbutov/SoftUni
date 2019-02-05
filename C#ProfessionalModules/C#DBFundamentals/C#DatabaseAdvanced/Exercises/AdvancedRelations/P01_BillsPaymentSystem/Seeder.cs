using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace P01_BillsPaymentSystem
{
    public class Seeder
    {
        public Seeder()
        {

        }

        public void Seed(BillsPaymentSystemContext context)
        {
            SeedCredicCards(context);
            SeedBankAccounts(context);
            SeedUsers(context);
            SeedPaymentMethods(context);

            //does not save false info in database
            TrySeedFalsePaymentMethods(context);
        }

        private static void TrySeedFalsePaymentMethods(BillsPaymentSystemContext context)
        {
            var falsePaymentMethod = new PaymentMethod()
            {
                Type = Data.Models.Enums.Type.CreditCard,
                BankAccountId = 1,
                CreditCardId = 1,
                UserId = 1
            };

            if (IsValid(falsePaymentMethod))
            {
                context.PaymentMethods.Add(falsePaymentMethod);
                context.SaveChanges();
            }

            var falsePaymentMethod2 = new PaymentMethod()
            {
                Type = Data.Models.Enums.Type.CreditCard,
                BankAccountId = null,
                CreditCardId = null,
                UserId = 1
            };

            if (IsValid(falsePaymentMethod2))
            {
                context.PaymentMethods.Add(falsePaymentMethod2);
                context.SaveChanges();
            }
        }

        private static void SeedPaymentMethods(BillsPaymentSystemContext context)
        {
            PaymentMethod[] paymentMethods = new PaymentMethod[]
                        {
                new PaymentMethod()
                {
                    //Id = 1,
                    Type = Data.Models.Enums.Type.BankAccount,
                    BankAccountId = 1,
                    CreditCardId = null,
                    UserId = 1
                },

                new PaymentMethod()
                {
                    //Id = 2,
                    Type = Data.Models.Enums.Type.CreditCard,
                    BankAccountId = null,
                    CreditCardId = 1,
                    UserId = 2
                }
                        };

            foreach (var paymentMethod in paymentMethods)
            {
                if (IsValid(paymentMethod))
                {
                    context.Add(paymentMethod);
                }
            }

            context.SaveChanges();
        }

        private static void SeedUsers(BillsPaymentSystemContext context)
        {
            User[] users = new User[]
                        {
                new User()
                {
                    //UserId = 1,
                    FirstName = "Purvan",
                    LastName = "Purvanov",
                    Email = "purvana@hotmail.com",
                    Password = "tainaParola",
                },

                new User()
                {
                    //UserId = 2,
                    FirstName = "Vtoran",
                    LastName = "Vtoranov",
                    Email = "vtorancho@hotmail.com",
                    Password = "poTainaParola",
                }
                        };

            foreach (var user in users)
            {
                if (IsValid(user))
                {
                    context.Add(user);
                }
            }

            context.SaveChanges();
        }

        private static void SeedBankAccounts(BillsPaymentSystemContext context)
        {
            BankAccount[] bankAccounts = new BankAccount[]
            {
                new BankAccount()
                {
                    //BankAccountId = 1,
                    BankName = "Na Barbuta Bankata",
                    SWIFTCode = "111222111"
                },

                new BankAccount()
                {
                    //BankAccountId = 2,
                    BankName = "Na Barbuta Bankata",
                    SWIFTCode = "222111222"
                }
            };

            bankAccounts[0].Deposit(1000.0m);
            bankAccounts[1].Deposit(5000.0m);

            foreach (var bankAccount in bankAccounts)
            {
                if (IsValid(bankAccount))
                {
                    context.Add(bankAccount);
                }
            }

            context.SaveChanges();
        }

        private static void SeedCredicCards(BillsPaymentSystemContext context)
        {
            CreditCard[] creditCards = new CreditCard[]
            {
                new CreditCard()
                {
                    //CreditCardId = 1,
                    ExpirationDate = DateTime.Now,
                },

                new CreditCard()
                {
                    //CreditCardId = 2,
                    ExpirationDate = DateTime.Today,
                }
            };

            creditCards[0].Deposit(1000.0m);
            creditCards[1].Deposit(1000.0m);

            foreach (var creditCard in creditCards)
            {
                if (IsValid(creditCard))
                {
                    context.Add(creditCard);
                }
            }

            context.SaveChanges();
        }

        private static bool IsValid(object obj)
        {
            return Validator.TryValidateObject(obj, new ValidationContext(obj),
                                               new List<ValidationResult>(), true);
        }
    }
}
