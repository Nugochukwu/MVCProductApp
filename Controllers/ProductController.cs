using Microsoft.AspNetCore.Mvc;
using MVCProductApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVCProductApp.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> _products = new List<Product>();
        private static int _nextId = 1;

        public IActionResult Index()
        {
            return View(_products);
        }

       
        public IActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.ID == id);
            if (_products == null) return NotFound();
            return View(product);
        }

        // Get Product/Create
        public IActionResult create()
        {
            return View();
        }

        // Post Product/Create
        [HttpPost]
        public IActionResult Create(Product product) 
        {
            if (ModelState.IsValid)
            {
                product.ID = _nextId++;
                _products.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
        
        //GET Product/Edit
        public IActionResult Edit(int id)
        {
            var product = _products.FirstOrDefault(p => p.ID == id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            var foundProduct = _products.FirstOrDefault(p => p.ID == product.ID);
            if (foundProduct == null) return NotFound();

            foundProduct.Name = product.Name;
            foundProduct.Price = product.Price;
            foundProduct.Description = product.Description;

            return RedirectToAction(nameof(Index));
        }

        //GET Product/Delete
        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.ID == id);
            if (product != null) _products.Remove(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
