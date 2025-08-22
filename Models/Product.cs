
using System.ComponentModel.DataAnnotations;
namespace MVCProductApp.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name must be under 100 characters")]
        public string Name { get; set; } = "";

        [Range(0, 1000000, ErrorMessage = "Price must be between 0 and 1,000,000")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name must be under 100 characters")]
        public string Description { get; set; }
    }
}
