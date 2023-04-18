using System.ComponentModel.DataAnnotations;

namespace MenuManager.Ui.WebApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
