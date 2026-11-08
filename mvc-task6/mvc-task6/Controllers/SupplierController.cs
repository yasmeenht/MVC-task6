using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_task6.Data;
using mvc_task6.Models;

namespace mvc_task6.Controllers
{
    public class SupplierController : Controller
    {

        private readonly ApplicationDbContext _context;

        public SupplierController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {

            List<Supplier> suppliers = _context.Suppliers.ToList();
            return View(suppliers);
        }


        [HttpPost]
        public IActionResult AddSupplier(string name, string phone, string email)
        {
            Supplier supplier = new Supplier
            {
                Name = name,
                Phone = phone,
                Email = email
            };
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
