using Microsoft.EntityFrameworkCore;

namespace New_Ecommerce.Models.Entities
{
    public class MyApp : DbContext
    {
        public MyApp(DbContextOptions<MyApp> options) : base(options) { }
        public DbSet<Product> products {  get; set; }
        public DbSet<Order> orders { get;set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
    }
}
