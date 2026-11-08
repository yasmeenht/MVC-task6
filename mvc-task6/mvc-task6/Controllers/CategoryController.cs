using Microsoft.AspNetCore.Mvc;
using mvc_task6.Data;
using mvc_task6.Models;

namespace mvc_task6.Controllers

{
    
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();
            return View(categories);
        
        }

        [HttpPost]
        public IActionResult AddCategory(int id, string name, string description)
        {
            Category category = new Category
            {
                Name = name,
                Description = description
            };
            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
