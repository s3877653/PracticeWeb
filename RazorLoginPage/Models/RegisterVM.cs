using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using RazorLoginPage.Helpers;

namespace RazorLoginPage.Models
{
	public class RegisterVM
	{
		[MinLength(4,ErrorMessage ="User Name must have atleast 4 character")]
		[Required]
		[BindProperty]
		public string UserName { get; set; }
		[Required]
		[EmailAddress(ErrorMessage ="Email not in the correct form")]
		[BindProperty]
		public string Email { get; set; }
		[Required]
		[BindProperty]
		[PasswordValidator]
		public string Password { get; set; }
		[Compare(nameof(Password), ErrorMessage ="Confirm password must match the password!")]
		public string? ConfirmPassword { get; set; }
	}
}
