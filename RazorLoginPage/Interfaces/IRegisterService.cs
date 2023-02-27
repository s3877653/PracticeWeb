using RazorLoginPage.Data;

namespace RazorLoginPage.Interfaces
{
    public interface IRegisterService
    {
        public bool CheckNameExist(ApplicationDBContext _dbContext, string Name);
        public bool CheckEmailExist(ApplicationDBContext _dbContext, string Email);
    }
}
