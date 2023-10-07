namespace MovieStore.Models.ViewModels
{
    public class CartMovieVM
    {
        public Movie Movie { get; set; }
        public int NoOfCopies { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
    }
}
