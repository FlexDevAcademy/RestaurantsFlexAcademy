using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantsFlexDevAcademy.Models
{
    public class Restaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Type of food")]
        public CuisineType Cuisine { get; set; }
    }
}
