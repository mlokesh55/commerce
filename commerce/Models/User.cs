using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using commerce.Models;

namespace commerce.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name must contain only letters.")]
        public required string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email.")]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password must be at least 8 characters long and include an uppercase letter, a lowercase letter, a number, and a special character.")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Please re-enter the password.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public required string ConfirmPassword { get; set; }

        [Required]
        public required string Role { get; set; }

        [JsonIgnore]
        public  ShoppingCart ShoppingCart { get; set; }
    }
}