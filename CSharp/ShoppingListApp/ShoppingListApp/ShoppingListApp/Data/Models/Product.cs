using System.ComponentModel.DataAnnotations;

namespace ShoppingListApp.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public IList<ProductNote> ProductNotes { get; set; } = new List<ProductNote>();
    }
}
