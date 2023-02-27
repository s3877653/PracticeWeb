using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorLoginPage.Data;
using RazorLoginPage.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Cryptography.X509Certificates;
using RazorLoginPage.Interfaces;

namespace RazorLoginPage.Pages.LoginVModel
{
    public class IndexModel : PageModel
    {

		private readonly ApplicationDBContext _dbContext;
        private readonly ILoginService _loginService;

        public LoginVM loginVM { get; set; }

        public IndexModel(ApplicationDBContext dBContext, ILoginService loginService)
        {
            _dbContext= dBContext;
            _loginService= loginService;
        }
		public IActionResult OnGet()
        {
            ClaimsPrincipal userClaim = HttpContext.User;
            if (userClaim.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Users/UserHomePage");
            }
            return Page();
        }

        public async Task<IActionResult> OnPost(LoginVM loginVM)
        {
            bool isLoginLegit = _loginService.LoginValidator(_dbContext, loginVM.Email, loginVM.Password);
            if(isLoginLegit)
            {
                var claims = new List<Claim>() {
                    new Claim(ClaimTypes.Email, loginVM.Email)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = loginVM.KeepLoggedIn
                };
               await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity)
                   ,properties);               
                return RedirectToPage("/Users/UserHomePage");
            }
            bool isLoginAdmin= _loginService.LoginAdmin(loginVM.Email, loginVM.Password);
            if(isLoginAdmin)
            {
				var adminClaims = new List<Claim>() {
					new Claim(ClaimTypes.Email, "admin"),
                    new Claim("role","admin")
				};
				ClaimsIdentity adminClaimsIdentity = new ClaimsIdentity(adminClaims, CookieAuthenticationDefaults.AuthenticationScheme);
				AuthenticationProperties properties = new AuthenticationProperties()
				{
					AllowRefresh = true,
					IsPersistent = loginVM.KeepLoggedIn
				};
				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(adminClaimsIdentity)
					, properties);
				return RedirectToPage("/Admins/AdminUserList");
            }
            ViewData["LoginFail"] = "Incorrect user name or password";
            return Page();
        }
    }
}
