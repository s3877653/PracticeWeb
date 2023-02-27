using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorLoginPage.Data;
using RazorLoginPage.Models;

namespace RazorLoginPage.Pages.Users
{
    [BindProperties]
    public class EditModel : PageModel
    {
        ApplicationDBContext _dbContext;
        public User User { get; set; }
        public EditModel(ApplicationDBContext dBContext)
        {
            _dbContext= dBContext;
        }
        public void OnGet(int id)
        {
            User = _dbContext.Users.Find(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
				_dbContext.Update(User);
				await _dbContext.SaveChangesAsync();
				return RedirectToPage("Index");
			}
            return Page();
            
        }
    }
}
