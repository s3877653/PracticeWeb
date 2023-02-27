using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace RazorLoginPage.Helpers
{
	public class PasswordValidator : ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			string password = value.ToString();
			if (!Regex.Match(password, @"^(?=.*[a-z]).{0,}$").Success)
			{
				return new ValidationResult("Password must contain at least one lower case letter");
			}
			if (!Regex.Match(password, @"^(?=.*[A-Z]).{0,}$").Success)
			{
				return new ValidationResult("Password must contain at least one UPPER case letter");
			}
			if (!Regex.Match(password, @"^(?=.*\d).{0,}$").Success)
			{
				return new ValidationResult("Password must contain at least one number");
			}
			if (!Regex.Match(password, @"^(?=.*[!@#$%^&+=]).{0,}$").Success)
			{
				return new ValidationResult("Password must contain at least one special character");
			}


			return ValidationResult.Success;
		}
	}
}
