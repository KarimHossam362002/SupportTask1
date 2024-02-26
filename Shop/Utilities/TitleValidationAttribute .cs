using System.ComponentModel.DataAnnotations;
/*add this to use regular expre*/
using System.Text.RegularExpressions;

namespace Shop.Utilities
{
    public class TitleValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string title = value.ToString();
                if (!Regex.IsMatch(title, @"^[a-zA-Z0-9\s]+$"))
                {
                    return new ValidationResult("The title can only contain letters, numbers, and spaces.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
