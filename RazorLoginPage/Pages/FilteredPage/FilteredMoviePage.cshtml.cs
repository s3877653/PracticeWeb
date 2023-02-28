using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorLoginPage.Interfaces;
using RazorLoginPage.Models;

namespace RazorLoginPage.Pages.FilteredPage
{
    public class FilteredMoviePageModel : PageModel
    {
		public static List<string> actors = new()
		{
			"khoi","nam","khang"
		};
		public static List<string> catergories1 = new()
		{
			"action","romance","horror"
		};
		public static List<string> catergories2 = new()
		{
			"funny","vintage","phylosophy"
		};
		public static List<string> catergories3 = new()
		{
			"war","sport","cartoon"
		};
		public static List<string> catergories4 = new()
		{
			"cartoon","Ci-fi","Anime"
		};
		public List<Movie> movieList = new() {
			new Movie(1,"pokemon","Full HD","phim hoat hinh vui",true,2002,catergories1,"Nam","","","1h20p","nhat ban",9.8,actors,1_232_221),
			new Movie(2,"doraemon","Full HD engsub","phim hoat hinh tuoi tho",false,2012,catergories4,"Na","13","24","24 phut","nhat ban",9.5,actors,1_200_300),
			new Movie(3,"tay du ki","Full HD vietsub","tan tay du ki",false,1990,catergories1,"BruceWang","30","100","30 phut","trung quoc",10.0,actors,9_600_400),
			new Movie(4,"nha ba nu","Full HD","phim tran thanh",true,2023,catergories3,"Tran thanh","","","2h20p","viet nam",8.0,actors,300_600),
			new Movie(5,"pursue of happiness","Full HD","phim document",true,1989,catergories1,"BruceWang","","","2h10p","my",10.0,actors,4_400_400),
			new Movie(6,"avatar 3","Full HD","phim hay",true,2025,catergories1,"BruceWang","","","3h10p","my",10.0,actors,0),
			new Movie(7,"naruto","Full HD engsub","phim anime",false,1990,catergories4,"ken","300","300","24p","nhat ban",10.0,actors,563_700),
			new Movie(8,"Breaking bad","Full HD engsub","phim hay",true,2012,catergories1,"BruceWang","25","25","30p","my",8.5,actors,563_800),
			new Movie(9,"2012","Full HD vietsub","phim tan the",true,2008,catergories1,"BruceWang","","","3h10p","my",9.9,actors,563_365),
			new Movie(10,"walking dead","Full HD vietsub","phim xac song",true,2006,catergories2,"BruceWang","","","3h10p","my",9.5,actors,5_000_000),
			new Movie(11,"pokemon2","Full HD vietsub","phim hoat hinh vui",true,2020,catergories2,"Nam","","","1h20p","nhat ban",9.8,actors,1_232_221),
			new Movie(12,"doraemon 2","Full HD","phim hoat hinh tuoi tho",false,2022,catergories4,"Na","24","24","24 phut","nhat ban",9.5,actors,1_200_300),
			new Movie(13," tantay du ki","Full HD","tan tay du ki2",false,1990,catergories3,"BruceWang","95","100","30 phut","trung quoc",10.0,actors,9_600_400),
			new Movie(14,"nha ba nu 2","Full HD","phim tran thanh",true,2026,catergories3,"Tran thanh","","","2h20p","han quoc",8.0,actors,0),
			new Movie(15,"pursue of happiness2","Full HD","phim document",true,2023,catergories1,"BruceWang","","","2h10p","my",10.0,actors,4_400_400),
			new Movie(16,"avatar 4","Full HD engsub","phim hay",true,2026,catergories1,"BruceWang","","","3h10p","my",10.0,actors,0),
			new Movie(17,"naruto shipuden","Full HD engsub","phim anime",false,2012,catergories4,"ken","269","300","24p","han quoc",10.0,actors,563_700),
			new Movie(18,"Breaking bad2","Full HD vietsub","phim hay",true,2020,catergories1,"BruceWang","25","25","30p","my",8.5,actors,563_800),
			new Movie(19,"2025","Full HD vietsub","phim tan the",true,2023,catergories1,"BruceWang","","","3h10p","my",9.9,actors,563_365),
			new Movie(20,"walking dead2","Full HD vietsub","phim xac song",true,2012,catergories1,"BruceWang","","","3h10p","my",9.5,actors,5_000_000)
		};
		[BindProperty]
		public int MovieID { get; set; }
		public string FilterString { get; set; }
		public int FilterInt { get; set; }
		[BindProperty(SupportsGet = true)]
		public string StringSearch { get; set; }
		public List<Movie> FilteredMovie = new();
		private readonly ISearchService _searchService;

		public FilteredMoviePageModel(ISearchService searchService)
		{
			
			_searchService = searchService;
		}
		public void OnGet(string filterString = "",int filterInt=0)
        {
			FilteredMovie = _searchService.SearchMovieService(movieList, StringSearch);
			FilterString = filterString;
			FilterInt = filterInt;
        }
		public IActionResult OnPostMovieHandler()
		{

			//khi nhấn vào ô phim sẽ post id lên url
			return RedirectToPage("/Movies/MovieInfoPage", new { id = MovieID });
		}
	}
}
