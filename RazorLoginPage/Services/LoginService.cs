using RazorLoginPage.Data;
using RazorLoginPage.Interfaces;

namespace RazorLoginPage.Services
{
    public class LoginService : ILoginService
    {
        public bool LoginAdmin(string email, string password)
        {
            if (email.Equals("admin") && password.Equals("admin"))
            {
                return true;
            }
            return false;
        }

        public bool LoginValidator(ApplicationDBContext dBContext, string email, string password)
        {
            if (dBContext.Users.Any(u => u.Email == email && u.Password == password))
            {
                return true;
            }
            return false;
        }
    }
}
