using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using New_Ecommerce.Models.Entities;

namespace New_Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        private readonly MyApp app;
        public ProductController(MyApp app)
        {
            this.app = app;
        }
        public async Task<IActionResult> GetProducts()
        {
            var p = await app.products.ToListAsync();
            return View(p);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (product == null)
            {
                return View(product);
            }
            await app.products.AddAsync(product);
            await app.SaveChangesAsync();
            return RedirectToAction("GetProducts");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id) {
            var p = await app.products.FirstOrDefaultAsync(i => i.ProductID == id);
            if(p != null)
            {
                return View(p);
            }
            return View();
        
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Product product,int id)
        {
            var p = await app.products.FirstOrDefaultAsync(i => i.ProductID == id);
            if (p != null)
            {
                p.ProductName = product.ProductName;
                p.ProductDescription = product.ProductDescription;
                p.Price = product.Price;
                p.StockQuantity = product.StockQuantity;
                app.products.Update(p);
                await app.SaveChangesAsync();
                return RedirectToAction("GetProducts");
            }
            return View(p);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var p = await app.products.FirstOrDefaultAsync(i => i.ProductID == id);
            if (p != null)
            {
                return View(p);
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Delete(Product product,int id)
        {
            var p = await app.products.FirstOrDefaultAsync(i => i.ProductID == id);
            if (p != null)
            {
               
                app.products.Remove(p);
                await app.SaveChangesAsync();
                return RedirectToAction("GetProducts");
            }
            return View(p);
        }
    }
}
