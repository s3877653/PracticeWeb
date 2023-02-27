using Microsoft.EntityFrameworkCore;
using RazorLoginPage.Models;

namespace RazorLoginPage.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        {

        }
        public DbSet<User> Users { get; set; }
        
    }
    
}
