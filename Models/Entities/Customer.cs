using System.ComponentModel.DataAnnotations;

namespace New_Ecommerce.Models.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}
