namespace MovieStore.Models.ViewModels
{
    public class FrontPageVM
    {
        public List<Movie> Top5Movies { get; set; }
        public List<Movie> Top5NewestMovies { get; set; }
        public List<Movie> Top5OldestMovies { get; set; }
        public List<Movie> Top5CheapestMovies { get; set; }

        Customer OurBestCustomer { get; set; }

    }
}
