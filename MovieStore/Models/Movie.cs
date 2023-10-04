using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MovieStore.Models
{
    public class Movie
    {

        public int Id { get; set; }

        [Required]
        [StringLength(
            maximumLength: 100,
            MinimumLength = 1,
            ErrorMessage = "Max 100 characters, Min 2 characters")]

        public string Title { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        [DisplayName("Release Year")]
        public int ReleaseYear { get; set; }

        [StringLength(300)]
        public string ImgURL { get; set; }

        [Required]
        public decimal Price { get; set; }



        public virtual ICollection<OrderRow> OrderRows { get; set; }
       
    }
}
