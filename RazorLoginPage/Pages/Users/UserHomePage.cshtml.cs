using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorLoginPage.Pages.Users
{
    [Authorize]
    public class UserHomePageModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
