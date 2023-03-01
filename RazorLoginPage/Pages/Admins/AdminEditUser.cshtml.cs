using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorLoginPage.Data;
using RazorLoginPage.Models;

namespace RazorLoginPage.Pages.Admins
{
    public class AdminEditUserModel : PageModel
    {
        private readonly ApplicationDBContext _dbContext;
        [BindProperty]
        public User User { get; set; }

        public AdminEditUserModel(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;       
        }
        public void OnGet(int id)
        {
            User = _dbContext.Users.Find(id);
        }

        public async Task<IActionResult> OnPostEditUser()
        {
            _dbContext.Update(User);
            await _dbContext.SaveChangesAsync();
            return RedirectToPage("AdminUserList");
        }
    }
}
