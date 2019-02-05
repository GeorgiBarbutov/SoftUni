using System;
using System.ComponentModel.DataAnnotations;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class BankAccount
    {
        private const string NON_POSITIVE_AMOUNT = "Amount must be bigger than 0";
        private const string INSUFFICIENT_FUNDS = "Insufficient funds";

        [Required]
        [Key]
        public int BankAccountId { get; set; }

        [Required]
        public decimal Balance { get; private set; }

        [Required]
        [MaxLength(50)]
        public string BankName { get; set; }

        [Required]
        [MaxLength(20)]
        public string SWIFTCode { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public void Withdraw(decimal amount)
        {
            if(amount <= 0)
            {
                Console.WriteLine(NON_POSITIVE_AMOUNT);
            }
            else if(amount > this.Balance)
            {
                Console.WriteLine(INSUFFICIENT_FUNDS);
            }
            else
            {
                this.Balance -= amount;
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine(NON_POSITIVE_AMOUNT);
            }
            else
            {
                this.Balance += amount;
            }
        }
    }
}
