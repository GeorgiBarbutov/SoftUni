using System;
using System.ComponentModel.DataAnnotations;

namespace P01_BillsPaymentSystem.Data.Models.CustomAtributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class XorAtribute : ValidationAttribute
    {
        private const string SAME_VALUE_ERROR = "One of the values must be null and the other must not!";

        private string targrtAttribute;

        public XorAtribute(string targrtAttribute)
        {
            this.targrtAttribute = targrtAttribute;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var target = validationContext.ObjectType
                                          .GetProperty(targrtAttribute)
                                          .GetValue(validationContext.ObjectInstance);

            if((target == null && value == null) || (target != null && value != null))
            {
                return new ValidationResult(SAME_VALUE_ERROR);
            }

            return ValidationResult.Success;
        }
    }
}
