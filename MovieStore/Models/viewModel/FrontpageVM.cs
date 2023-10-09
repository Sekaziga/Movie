namespace MovieStore.Models.viewModel
{
    public class FrontpageVM
    {
        public List<Movie>? top5movies { get; set; }
        public List<Movie>? top5newestmovies { get; set; }
        public List<Movie>? top5oldestmovies { get; set; }
        public List<Movie>? top5cheapestmovies { get; set; }
    }
}
