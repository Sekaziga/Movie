using System.ComponentModel;

namespace MovieStore.Models
{
    public class Order
    {
        public int Id { get; set; }

        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        [DisplayName("Customer Id")]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderRow> OrderRows { get; set; }


    }
}
