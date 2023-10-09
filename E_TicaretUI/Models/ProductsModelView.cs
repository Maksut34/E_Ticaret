using System.ComponentModel.DataAnnotations;

namespace E_TicaretUI.Models
{
    public class ProductsModelView
    {
        [Required]
        public string name { get; set; }
        [Required]
        public IFormFile ımage { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public int piece { get; set; }
        [Required]
        public string category { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
