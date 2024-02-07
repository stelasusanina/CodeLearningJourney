using Microsoft.AspNetCore.Mvc;
using ShoppingListApp.Data;
using ShoppingListApp.Data.Models;
using ShoppingListApp.Models;

namespace ShoppingListApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShoppingListDbContext data;
        public ProductController(ShoppingListDbContext _data)
        {
            data = _data;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult All()
        {
            var products = data.Products
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToList();

            return View(products);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel model) 
        {
            var product = new Product
            {
                Name = model.Name,
            };

            data.Products.Add(product);
            data.SaveChanges();

            return RedirectToAction("All");
        }

        public IActionResult Edit(int id)
        {
            var product = data.Products.Find(id);

            return View(new ProductViewModel
            {
                Name = product.Name
            });
        }

        [HttpPost]
        public IActionResult Edit(int id, Product model)
        {
            var product = data.Products.Find(id);
            product.Name = model.Name;

            data.SaveChanges();
            return RedirectToAction("All");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var product = data.Products.Find(id);
            data.Products.Remove(product);
            data.SaveChanges();

            return RedirectToAction("All");
        }
    }
}
