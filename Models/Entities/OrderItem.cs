using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace New_Ecommerce.Models.Entities
{
    public class OrderItem
    {
        [Key]
        public int OrderItemID { get; set; }
        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Product Product { get; set; }
        public int OrderID { get;set; }
        [ForeignKey("OrderID")]
        public Order Order{ get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }

    }
}
