using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using New_Ecommerce.Models.Entities;
using New_Ecommerce.Models.ViewModel;

namespace New_Ecommerce.Controllers
{
    public class OrderController : Controller
    {
        private readonly MyApp app;
        public OrderController(MyApp app)
        {
            this.app = app;
        }
        public async Task<IActionResult> Index()
        {
            var ord = await app.orders.Include(o => o.Customer).ToListAsync();
            return View(ord);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            OrderViewModel model = new OrderViewModel()
            {
                Customers = await app.customers.ToListAsync(),
                Products = await app.products.ToListAsync()
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(OrderViewModel model)
        {
            var p = await app.products.FirstOrDefaultAsync(i => i.ProductID == model.ProductID);
            Order order = new Order()
            {
                date = model.date,
                TotalAmount = p.Price * p.StockQuantity,
                CustomerID = model.CustomerID,
                OrderItems = new List<OrderItem>(),
            };
            var pp = await app.orders.OrderBy(v => v.OrderID).LastOrDefaultAsync();
            OrderItem item = new OrderItem()
            {
                quantity = model.quantity,
                price = p.Price,
                ProductID = model.ProductID,
                OrderID = (pp.OrderID < 1)?1:pp.OrderID,
            };
            app.orderItems.Add(item);
            await app.orders.AddAsync(order);
            await app.SaveChangesAsync();
            return RedirectToAction("Index");
        }
       

    }
}
