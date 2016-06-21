using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XBoxRentals.Utility
{
    public class Helper
    {
        public static int CalculateAge(DateTime birthday)
        {
            var today = DateTime.Today;
            var age = today.Year - birthday.Year;
            if (birthday > today.AddYears(-age))
                age--;

            return age;
        }
    }
}