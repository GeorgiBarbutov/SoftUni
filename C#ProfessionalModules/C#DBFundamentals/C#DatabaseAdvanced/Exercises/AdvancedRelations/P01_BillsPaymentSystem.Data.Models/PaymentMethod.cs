using P01_BillsPaymentSystem.Data.Models.CustomAtributes;
using P01_BillsPaymentSystem.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class PaymentMethod
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public Type Type { get; set; }

        [Required]
        public int UserId { get; set; }
        public User User { get; set; }

        [XorAtribute(nameof(CreditCardId))]
        public int? BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }

        public int? CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}
