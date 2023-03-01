using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorLoginPage.Data;
using RazorLoginPage.Models;

namespace RazorLoginPage.Pages.Users
{
    [Authorize(Policy = "IsAdmin")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _dbContext;
        public IEnumerable<User> Users { get; set; }
		public IEnumerable<User> FilteredUsers { get; set; }
		public User CurrentUser { get; set; }
        [BindProperty]
        public string SearchString { get; set; }

        public IndexModel(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet(string searchString="")
        {			
			Console.WriteLine(searchString);
			if (!string.IsNullOrEmpty(searchString))
            {
				Console.WriteLine("testzzzzzzzzzzzzzz");
				Users = _dbContext.Users.Where(u => u.UserName.Contains(searchString)
											   || u.Email.Contains(searchString)).ToList();				               
            }
            else
            {
				Console.WriteLine("test1");
				
				Users = _dbContext.Users;

			}                                              			           
		}
        
        public async Task<IActionResult> OnPostDeleteHandler(int id)
        {           
			CurrentUser = _dbContext.Users.FirstOrDefault(u => u.UserId == id);
			_dbContext.Remove(CurrentUser);
            await _dbContext.SaveChangesAsync();
            OnGet();
            return Page();
        }
    }
}
