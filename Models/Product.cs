
using System.ComponentModel.DataAnnotations;
namespace MVCProductApp.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
