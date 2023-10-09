using E_TicaretEntity;

namespace E_TicaretUI.Models
{
    public class Products
    {
        public int ProductsId { get; set; }
        public string name { get; set; }
        public string Description { get; set; }
        public string ımage { get; set; }
        public decimal Price { get; set; }
        public int piece { get; set; }
        public string category { get; set; }
        public List<Product> myProducts { get; set; }
        public List<Image> myImages { get; set; }
    }
}
