using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Caravan.Service.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CheckNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            double result = 0;
            if(value is not null && double.TryParse(value.ToString(), out result))
            {
                if (result <= 0)
                    return new ValidationResult("Weight must be bigger than 0");
                return ValidationResult.Success;
            }
            return new ValidationResult("Must be contain only number!");
        }
    }
}
