using System.Security.Cryptography.X509Certificates;
using RazorLoginPage.Interfaces;
using RazorLoginPage.Models;

namespace RazorLoginPage.Services
{
    public class SearchService : ISearchService
    {
        public List<Movie> SearchMovieService(IEnumerable<Movie> movies, string searchString = null)
        {

		
			if (string.IsNullOrEmpty(searchString))
			{
				return movies.ToList();
			}
			return movies.Where(movie => movie.Title.Contains(searchString) ||
			movie.Director.Contains(searchString) || movie.Actors.Contains(searchString)).ToList();
			
				
				
			
		}
    }
}
