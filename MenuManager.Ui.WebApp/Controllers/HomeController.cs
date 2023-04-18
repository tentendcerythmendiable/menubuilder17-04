using System.Collections;
using MenuManager.Ui.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MenuManager.Ui.WebApp.Core;

namespace MenuManager.Ui.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly MenuManagerDbContext _menuManagerDbContext;
        
        public HomeController(MenuManagerDbContext menuManagerDbContext)
        {
            _menuManagerDbContext = menuManagerDbContext;
        }
        
        public IActionResult Index()
        {
            var products = _menuManagerDbContext.Products.ToList();

            return View(products);
        }

        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}