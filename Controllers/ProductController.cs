using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCProductApp.Models;
using MVCProductApp.Models;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;



namespace MVCProductApp.Controllers
{
    public class ProductController : Controller
    {
        //Getting the DB context from  the class file.
        private readonly ApplicationDbContext _context;

        //??
        public ProductController(ApplicationDbContext context)
        {
            //initializing the context variable.
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

       
        public async Task<IActionResult> Details(int id)
        {
            //Checking the database/context for the Product with the specified field id.
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            
            return View(product);
        }

        // Get Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // Post Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(Product product) 
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        
        //GET Product/Edit

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            try
            {
                _context.Update(product);
                await _context.SaveChangesAsync();
                TempData["Message"] = "Product updated successfully!";
            }
            catch (DbUpdateConcurrencyException) 
            { 
                if(!_context.Products.Any(p => p.ID == product.ID))
                {
                    return NotFound();
                }
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        //GET Product/Delete
        public async Task<IActionResult> Delete(int id)
        {
            
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
