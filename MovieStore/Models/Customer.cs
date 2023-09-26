using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MovieStore.Models
{
    public class Customer
    {

        public int Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Billing Address")]
        public string BillingAddress { get; set; }

        [DisplayName("Billing Zip")]
        public string BillingZip { get; set; }

        [DisplayName("Billing City")]
        public string BillingCity { get; set; }

        [DisplayName("Delivery Address")]
        public string DeliveryAddress { get; set; }

        [DisplayName("Delivery Zip")]
        public string DeliveryZip { get; set; }

        [DisplayName("Delivery City")]
        public string DeliveryCity { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

    }
}
