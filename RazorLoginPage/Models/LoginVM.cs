using System.ComponentModel.DataAnnotations;

namespace RazorLoginPage.Models
{
	public class LoginVM
	{
		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
		public bool KeepLoggedIn { get; set; }
	}
}
