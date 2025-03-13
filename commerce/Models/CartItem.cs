using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
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

        [JsonIgnore]
        public virtual ShoppingCart ShoppingCart { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public   Product Product { get; set; }

        [Required]
        [Range(1,100,ErrorMessage ="Quantity must be between 1 and 100")]
        public int Quantity { get; set; }

        [NotMapped]
        public decimal TotalPrice => Product != null ? Quantity * Product.Price : 0M;
    }
}