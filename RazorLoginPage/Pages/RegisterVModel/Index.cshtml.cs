using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorLoginPage.Data;
using RazorLoginPage.Interfaces;
using RazorLoginPage.Models;

namespace RazorLoginPage.Pages.RegisterVModel
{

    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly IRegisterService _registerService;
        
        public RegisterVM RegisterVM { get; set; }
		
        public User User { get; set; }

        public IndexModel(ApplicationDBContext dBContext, IRegisterService registerService)
        {
            _dbContext = dBContext;
            _registerService = registerService;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {				
				bool isNameExist = _registerService.CheckNameExist(_dbContext, registerVM.UserName);
				if (isNameExist)
				{
					ViewData["NameExist"] = "User name already exist";
					Console.WriteLine("test1");
					return Page();
				}
				bool isEmailExist = _registerService.CheckEmailExist(_dbContext, registerVM.Email);
				if (isEmailExist)
				{
					ViewData["EmailExist"] = "Email already exist";
					Console.WriteLine("test2");
					return Page();
				}
				User user = new User();
				user.UserName = registerVM.UserName;
				user.Email = registerVM.Email;
				user.Password = registerVM.Password;
				await _dbContext.AddAsync(user);
				await _dbContext.SaveChangesAsync();
				ViewData["CreateSuccess"] = "Account created successfully";
				return RedirectToPage("/Users/Index");
			}
			return Page();
        }
    }
}
