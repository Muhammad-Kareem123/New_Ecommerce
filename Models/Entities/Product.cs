using System.ComponentModel.DataAnnotations;

namespace New_Ecommerce.Models.Entities
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductDescription { get; set; }
        public int StockQuantity { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
