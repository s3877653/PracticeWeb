using RazorLoginPage.Data;
using RazorLoginPage.Interfaces;

namespace RazorLoginPage.Services
{
    public class RegisterService : IRegisterService
    {
        public bool CheckEmailExist(ApplicationDBContext _dbContext, string Email)
        {
            if (_dbContext.Users.Any(u => u.Email == Email)) return true;
            return false;
        }

        public bool CheckNameExist(ApplicationDBContext _dbContext, string Name)
        {
            if (_dbContext.Users.Any(u => u.UserName == Name)) return true;
            return false;
        }
    }
}
