using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorLoginPage.Models;
using static System.Net.Mime.MediaTypeNames;

namespace RazorLoginPage.Pages.Movies
{
    public class MovieWatchPageModel : PageModel
    {
		public static List<string> actors = new()
		{
			"khoi","nam","khang"
		};
		public static List<string> allCatergory = new()
		{
			"action","romance","funny","vnitage","horror","phylosophy","war","sport","cartoon","Ci-fi","Anime"
		};
		public static List<string> catergories1 = new()
		{
			"action","romance","horror"
		};
		public static List<string> catergories2 = new()
		{
			"funny","vnitage","phylosophy"
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
			new Movie(1,"pokemon","phim hoat hinh vui",true,2002,catergories1,"Nam","","","1h20p","nhat ban",9.8,actors,1_232_221),
			new Movie(2,"doraemon","phim hoat hinh tuoi tho",false,2012,catergories4,"Na","13","24","24 phut","nhat ban",9.5,actors,1_200_300),
			new Movie(3,"tay du ki","tan tay du ki",false,1990,catergories1,"BruceWang","30","100","30 phut","trung quoc",10.0,actors,9_600_400),
			new Movie(4,"nha ba nu","phim tran thanh",true,2023,catergories3,"Tran thanh","","","2h20p","viet nam",8.0,actors,300_600),
			new Movie(5,"pursue of happiness","phim document",true,1989,catergories1,"BruceWang","","","2h10p","my",10.0,actors,4_400_400),
			new Movie(6,"avatar 3","phim hay",true,2025,catergories1,"BruceWang","","","3h10p","my",10.0,actors,563_700)
		};
		  
		public Movie Movie { get; set; }
        public void OnGet(int id)
        {
			//lấy thông tin movie từ id trên url
			Movie = movieList[id -1];

		}
    }
}
