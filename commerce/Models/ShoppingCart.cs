using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace commerce.Models
{
    public class ShoppingCart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public required User User { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}