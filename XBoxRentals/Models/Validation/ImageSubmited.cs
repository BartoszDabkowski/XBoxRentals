using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XBoxRentals.Utility;
using XBoxRentals.ViewModels;

namespace XBoxRentals.Models.Validation
{
    public class ImageSubmited : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var gameFormViewModel = (GameFormViewModel)validationContext.ObjectInstance;
            var httpPostedFileBase = gameFormViewModel.File;
            var imageId = gameFormViewModel.ImageId;

            if (httpPostedFileBase == null && imageId == 0)
                return new ValidationResult("Please choose an Image.");

            return ValidationResult.Success;
        }
    }
}