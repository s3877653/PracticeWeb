using RazorLoginPage.Data;

namespace RazorLoginPage.Interfaces
{
    public interface ILoginService
    {
        public bool LoginValidator(ApplicationDBContext dBContext, string email, string password);
        public bool LoginAdmin(string email, string password);
    }
}
