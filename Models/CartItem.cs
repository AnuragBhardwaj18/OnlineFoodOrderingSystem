namespace FoodOrdering.Web.Models
{
    public class CartItem
    {
        public int Id { get; set; }

        public string UserId { get; set; } = string.Empty;

        public int FoodItemId { get; set; }

        public FoodItem? FoodItem { get; set; }

        public int Quantity { get; set; }
    }
}