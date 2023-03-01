using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorLoginPage.Data;
using RazorLoginPage.Models;

namespace RazorLoginPage.Pages.Admins
{
    public class AdminCreateUserModel : PageModel
    {
        private readonly ApplicationDBContext _dbContext;
        [BindProperty]
        public User User { get; set; }
        public AdminCreateUserModel(ApplicationDBContext dBContext)
        {
            _dbContext= dBContext;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult>OnPostCreateUser()
        {
            if(ModelState.IsValid)
            {
				await _dbContext.AddAsync(User);
				await _dbContext.SaveChangesAsync();
				return RedirectToPage("AdminUserList");
			}
            return Page();
            
        }
    }
}
