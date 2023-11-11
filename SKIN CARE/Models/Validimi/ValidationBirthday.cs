using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SKIN_CARE.Models.Validimi;
using System.ComponentModel.DataAnnotations;

namespace SKIN_CARE.Models.Validimi
{
    public class ValidationBirthday
    {
    }

    public class ValidimiDatelindjes : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime Datelindja = Convert.ToDateTime(value);

            if ((DateTime.Now.Year - Datelindja.Year) < 18)
            {
                return new ValidationResult("Jeni nen moshe, nuk mund te regjistroheni ne website!");
            }
            else
                return ValidationResult.Success;
        }

    }

}