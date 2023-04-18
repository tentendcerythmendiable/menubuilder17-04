using MenuManager.Ui.WebApp.Core;
using MenuManager.Ui.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MenuManager.Ui.WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MenuManagerDbContext _menuManagerDbContext;

        public ProductsController(MenuManagerDbContext menuManagerDbContext)
        {
            _menuManagerDbContext = menuManagerDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _menuManagerDbContext.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {

            if (!ModelState.IsValid)
            {
                return View(product);
            }

            product.CreatedDate = DateTime.Now;

            _menuManagerDbContext.Products.Add(product);
            _menuManagerDbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _menuManagerDbContext.Products
                .SingleOrDefault(p => p.Id == id);

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var dbProduct = _menuManagerDbContext.Products
                .SingleOrDefault(p => p.Id == product.Id);

            if (dbProduct is null)
            {
                return RedirectToAction("Index");
            }

            dbProduct.Name = product.Name;
            dbProduct.Description = product.Description;
            dbProduct.Price = product.Price;

            _menuManagerDbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
