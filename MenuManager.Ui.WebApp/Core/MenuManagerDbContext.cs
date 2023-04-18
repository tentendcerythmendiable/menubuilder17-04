using MenuManager.Ui.WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MenuManager.Ui.WebApp.Core
{
    public class MenuManagerDbContext : DbContext
    {
        public MenuManagerDbContext(DbContextOptions<MenuManagerDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products => Set<Product>();

        public void Seed()
        {
            AddProducts();
        }

        private void AddProducts()
        {
            Products.Add(new Product
            {
                Name = "Cola Zero",
                Price = 2,
                Description = "A Coca Cola drink.",
                CreatedDate = DateTime.UtcNow
            });
            Products.Add(new Product
            {
                Name = "Beer",
                Price = 2.5M,
                Description = "A cold one",
                CreatedDate = DateTime.UtcNow
            });
            Products.Add(new Product
            {
                Name = "Whiskey",
                Price = 10,
                Description = "From the highlands. Aged many years",
                CreatedDate = DateTime.UtcNow
            });


            SaveChanges();
        }
    }
}
