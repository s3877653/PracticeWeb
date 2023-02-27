using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorLoginPage.Data;
using RazorLoginPage.Models;

namespace RazorLoginPage.Pages.Users
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        ApplicationDBContext _dbContext;
        public User User { get; set; }
        public DeleteModel(ApplicationDBContext dBContext)
        {
            _dbContext= dBContext;
        }
        public void OnGet(int id)
        {
            User = _dbContext.Users.Find(id);
        }

        public async Task<IActionResult> OnPost(int id)
        {
			User = _dbContext.Users.Find(id);
			if (User != null)
            {
				_dbContext.Remove(User);
				await _dbContext.SaveChangesAsync();
				return RedirectToPage("Index");
			}
			    return Page();


		}
    }
}
