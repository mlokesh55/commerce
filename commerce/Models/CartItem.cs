using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using commerce.Models;

namespace commerce.Models
{
    public class CartItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartItemId { get; set; }

        [Required]
        public int CartId { get; set; }

        [ForeignKey("CartId")]
        public required ShoppingCart ShoppingCart { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public required Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [NotMapped]
        public decimal TotalPrice => Product != null ? Quantity * Product.Price : 0M;
    }
}