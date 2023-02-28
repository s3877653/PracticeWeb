using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorLoginPage.Pages.MovieWatch
{
    public class MovieWatchPageModel : PageModel
    {
        public int Id { get; set; }
        public void OnGet(int id)
        {
            Id=id;
        }
    }
}
