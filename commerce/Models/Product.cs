using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace commerce.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Name Length Exceeded")]
        public required string ProductName { get; set; }

        [Required]
        [StringLength(30)]
        public required string Description { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }

        [Required]
        public required string Category { get; set; }

        [Required]
        public required string ImageUrl { get; set; }
    }
}