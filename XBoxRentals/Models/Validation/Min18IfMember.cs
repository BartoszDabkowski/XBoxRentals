using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using XBoxRentals.Utility;

namespace XBoxRentals.Models.Validation
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            var age = Helper.CalculateAge(customer.BirthDate);

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer must be at least 18 years old to go on a membership.");
        }  
    }
}