using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class CreditCard
    {
        private const string NON_POSITIVE_AMOUNT = "Amount must be bigger than 0";
        private const string INSUFFICIENT_FUNDS = "Insufficient funds";

        [Required]
        [Key]
        public int CreditCardId { get; set; }

        [Required]
        public decimal Limit { get; private set; }

        [Required]
        public decimal MoneyOwed { get; private set; }

        [Required]
        [NotMapped]
        public decimal LimitLeft => Limit - MoneyOwed;

        [Required]
        public DateTime ExpirationDate { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine(NON_POSITIVE_AMOUNT);
            }
            else if (amount > this.LimitLeft)
            {
                Console.WriteLine(INSUFFICIENT_FUNDS);
            }
            else
            {
                this.MoneyOwed += amount;
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine(NON_POSITIVE_AMOUNT);
            }
            else
            {
                this.MoneyOwed -= amount;

                if(this.MoneyOwed < 0)
                {
                    this.Limit += Math.Abs(this.MoneyOwed);
                    this.MoneyOwed = 0;
                }
            }
        }
    }
}
