namespace MovieStore.Models.ViewModels
{
    //public class CartVM()
    //{

    //}
    public class CartVM
    {
        public List <CartMovieVM> Movie { get; set; } 
        public decimal Total { get; set; }
    }
    
    
}
