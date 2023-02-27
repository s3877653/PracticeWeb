using RazorLoginPage.Models;

namespace RazorLoginPage.Interfaces
{
    public interface ISearchService
    {
        public List<Movie> SearchMovieService(IEnumerable<Movie> movie, string searchString);
    }
}
