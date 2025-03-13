using System.ComponentModel.DataAnnotations;

namespace commerce.Models
{
    public class CartItemDto
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }

        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100")]
        public int Quantity { get; set; }
    }
}
