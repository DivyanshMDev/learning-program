using System.ComponentModel.DataAnnotations;

namespace RetailInventory.Domain
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        
        public Category Category { get; set; } = null!;
    }
}
