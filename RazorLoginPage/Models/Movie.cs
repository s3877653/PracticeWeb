namespace RazorLoginPage.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        
        public string Description { get; set; }
        public bool IsPhimLe { get; set; }
        public int AirYear { get; set;}
        public List<string> Category { get; set; }
        public string Director { get; set; }
        public string CurrentEpisodes { get; set; }
        public string MaxEpisode { get; set; }
        public string Length { get; set; }
        public string Nation { get; set; }
        public double IMDbScore { get; set; }
        public List<string> Actors { get; set; }
        public int View { get; set; }

        public Movie() {}
        

        
        public Movie(int id, string title, string description,bool isPhimLe,
            int airYear, List<string> category, string director,string currentEpisode,
            string maxEpisode ,string length, string nation, double iMDbScore,
            List<string> actors, int view)
        {
            Id = id;
            Title = title;
            Description = description;
            IsPhimLe= isPhimLe;
            AirYear = airYear;
            Category = category;
            Director = director;
            CurrentEpisodes = currentEpisode;
            MaxEpisode = maxEpisode;
            Length = length;
            Nation = nation;
            IMDbScore = iMDbScore;
            Actors = actors;
            View = view;
        }
    }
}
