using MovieStore.Data;
using MovieStore.Models;
using MovieStore.Models.ViewModels;

namespace MovieStore.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _db;
        private readonly IMovieService _movieService;

        public OrderService(AppDbContext db, IMovieService movieService)
        {
            _db = db;
            _movieService = movieService;

        }

        //List<Order> Orders { get; set; } = new List<Order>();


        //public List<Order> GetOrders()
        //{
        //    return _db.Orders.ToList();
        //}



        //public Order GetOrderById(int id)
        //{
        //    return _db.Orders.Find(id);
        //}

        //public void CreateOrder(Order newOrder)
        //{
        //    _db.Orders.Add(newOrder);
        //    _db.SaveChanges();

        //}


    //public bool UpdateOrder(Order newOrder)
    //{
    //    try
    //    {
    //        _db.Orders.Update(newOrder);
    //        _db.SaveChanges();
    //        return true;
    //    }



    //    catch (Exception ex)
    //    {
    //        return false;
    //    }
    //}



    //public bool DeleteOrder(int id)
    //{
    //    try
    //    {
    //        var data = GetOrderById(id);
    //        if (data == null)
    //        {
    //            return false;
    //        }
    //        _db.Orders.Remove(data);
    //        _db.SaveChanges();
    //        return true;
    //    }



    //    catch (Exception ex)
    //    {
    //        return false;
    //    }
    //}



    //public List<Order> Order()
    //{
    //    throw new NotImplementedException();
    //}

    //public CartVM GetCartVM(List<int> movieIdList)
    //{

    //    var uniqueMovies = _db.Movies
    //        .Where(m => movieIdList
    //        .Any(in => == m.Id));

    //    var cartMovies = movieIdList.GroupBy(x => x)
    //        .Select(g => new CartMovieVM()
    //        {
    //            Movie = uniquMovies
    //                .Where(mbox => mbox.Id == g.Key)
    //                .FirstOrDefault(),
    //            NoOfCopies = g.Count(),
    //            SubTotal = g.Count() * uniqueMovies
    //                .Where(m => m.Id == g.Key)
    //                .FirstOrDefault().Price

    //            )).ToList();

    //    CartVM cartVM = new CartVM();
    //    CartVM.CartMovies = cartMovies;
    //    cartVM.Total = cartMovies.Sum(GCMemoryInfo => GCMemoryInfo.SubTotal);

    //    return CartVM;

    //}

    public List<Movie> GetMostSoldMovies()
    {
        var groupMovies = _db.OrderRows.GroupBy(m => m.MovieId)
                       .Select(x => new
                       {
                           movieId = x.Key,
                           soldCopies = x.Count()
                       })
                       .OrderByDescending(x => x.soldCopies).Take(5).ToList();
        var popMovies = new List<Movie>();
        foreach (var item in groupMovies)
        {
            popMovies.Add(_movieService.GetMovie(item.movieId));
        }
        return popMovies;
    }

    public CartVM GetCartVM(List<int> movieIdList)
    {
        var uniqueMovies = _db.Movies
                    .Where(m => movieIdList
                    .Any(i => i == m.Id));

        var cartMovies = movieIdList.GroupBy(x => x)
            .Select(g => new CartMovieVM()
            {
                Movie = uniqueMovies
                .Where(m => m.Id == g.Key)
                .FirstOrDefault(),
                NoOfCopies = g.Count(),
                SubTotal = g.Count() * uniqueMovies
                .Where(m => m.Id == g.Key)
                .FirstOrDefault().Price
            }).ToList();

        CartVM cartVM = new CartVM();
        cartVM.CartMovies = cartMovies;
        cartVM.Total = cartMovies.Sum(cm => cm.SubTotal);

        return cartVM;
    }

    public void AddOrder(string email, List<CartMovieVM> cartMovies)
    {
        Order newOrder = new Order();
        newOrder.OrderDate = DateTime.Now;
        newOrder.Customer = _db.Customers
                            .Where(c => c.Email == email).FirstOrDefault();

        List<OrderRow> orderRows = new List<OrderRow>();
        foreach (var item in cartMovies)
        {
            for (int i = 0; i < item.NoOfCopies; i++)
            {
                OrderRow row = new OrderRow()
                {
                    MovieId = item.Movie.Id,
                    Price = item.Movie.Price
                };
                orderRows.Add(row);
            }
        }
        newOrder.OrderRows = orderRows;
        _db.Orders.Add(newOrder);
        _db.SaveChanges();
    }


    //public CartVM GetCartVM(List<int> movieList)
    //{
    //    CartVM cartVM = new CartVM();
    //    List<Movie> movies = new List<Movie>();

    //    movies = _db.Movies.Where(m => movieIdList.Any(i => m.Id == i)).ToList();

    //    cartVM.CartMovies = movies.GroupBy(m => m)
    //                    .Select(g => new CartMovieVM()
    //                    {
    //                        Movie = g.Key,
    //                        NoOfCopies = g.Count(),
    //                        SubTotal = g.Sum(m => m.Price)
    //                    }).ToList();

    //    cartVM cartVM = new CartVM();
    //    cartVM.CartMovies = cartMovies;
    //    cartVM.Total = cartMovies.Sum(cm => cm.SubTotal);

    //    foreach (var movieId in movieIdList)
    //    {

    //        movies.Add(_db.Movies.Where(m => m.Id == movieId).Fi;

    //    }

    //    var query = _db.Movies.Where
    //    var cartVM = new CartVM();
    //    return cartVM;
    //}




        }
}
