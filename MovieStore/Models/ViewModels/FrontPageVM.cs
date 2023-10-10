namespace MovieStore.Models.ViewModels
{
    public class FrontPageVM
    {
        public List<Movie> TopSellerMovies { get; set; }
        public List<Movie> CheapestMovies { get; set; }
        public List<Movie> OldestMovies { get; set; }
        public List<Movie> NewestMovies { get; set; }

        Customer OurBestCustomer { get; set; }

    }
}
