using System.ComponentModel;

namespace MovieStore.Models
{
    public class OrderRow
    {

        public int Id { get; set; }

        [DisplayName("Order Id")]
        public int OrderId { get; set; }

        [DisplayName("Movie Id")]
        public int MovieId { get; set; }

        public decimal Price { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Order Order { get; set; }



    }
}
