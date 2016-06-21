using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using XBoxRentals.Utility;

namespace XBoxRentals.Models.Validation
{
    public class Min13Years : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            var age = Helper.CalculateAge(customer.BirthDate);

            return (age >= 13)
                ? ValidationResult.Success
                : new ValidationResult("Customer must be at least 13 years old to sign up");
        }  
    }
}