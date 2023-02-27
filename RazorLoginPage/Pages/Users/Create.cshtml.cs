using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorLoginPage.Data;
using RazorLoginPage.Models;

namespace RazorLoginPage.Pages.Users
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        ApplicationDBContext _dbContext;
        public User User { get; set; }
        public CreateModel(ApplicationDBContext dBContext)
        {
            _dbContext= dBContext;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid) {
				await _dbContext.AddAsync(User);
				await _dbContext.SaveChangesAsync();
				return RedirectToPage("Index");
			}
            return Page();
            
        }
    }
}
