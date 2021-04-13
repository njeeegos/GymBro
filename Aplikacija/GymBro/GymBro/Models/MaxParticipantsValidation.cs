using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymBro.Models
{
    public class MaxParticipantsValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ev = (Event)validationContext.ObjectInstance;
            if (ev.MaxNumber < 2)
                return new ValidationResult("Broj maksimalnih učesnika mora biti veci od 2!");
            return ValidationResult.Success;
        }
    }
}