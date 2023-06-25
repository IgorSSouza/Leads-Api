using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model
{
    public class Lead
    {
        public int Id { get; set; }
        
        [MaxLength(100)]
        [Required(ErrorMessage = "The FirstName field is mandatory!")]
        public string? FirstName { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "The FullName field is mandatory!")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "The PhoneNumber field is mandatory!")]
        public int PhoneNumber { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "The Email field is mandatory!")]
        public string? Email { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "The Suburb field is mandatory!")]
        public string? Suburb { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "The Description field is mandatory!")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "The Price field is mandatory!")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Category is mandatory!")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int Status { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

    }
}
