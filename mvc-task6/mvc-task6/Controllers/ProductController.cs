using Microsoft.AspNetCore.Mvc;
using mvc_task6.Data;
using mvc_task6.Models;

namespace mvc_task6.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = _context.Products.ToList();
            return View(products);
        }

        [HttpPost]
        public IActionResult AddProduct(string name, decimal price, int quantity, int categoryId, int supplierId)
        {
            Product product = new Product
            {
                Name = name,
                Price = price,
                Quantity = quantity,
                CategoryId = categoryId,
                SupplierId = supplierId
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}