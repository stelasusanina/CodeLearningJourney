using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingListApp.Data.Models
{
    public class ProductNote
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;

        [ForeignKey(nameof(ProductId))]
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}