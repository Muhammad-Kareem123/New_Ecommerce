using New_Ecommerce.Models.Entities;

namespace New_Ecommerce.Models.ViewModel
{
    public class OrderViewModel
    {
        public DateTime date { get; set; }
        public int quantity { get; set; }
        public int CustomerID { get;set; }
        public int ProductID { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }
    }
}
