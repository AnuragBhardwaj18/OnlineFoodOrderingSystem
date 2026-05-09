using System.ComponentModel.DataAnnotations;

namespace FoodOrdering.Web.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public List<FoodItem>? FoodItems { get; set; }
    }
}