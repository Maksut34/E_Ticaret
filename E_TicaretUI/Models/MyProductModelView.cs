using E_TicaretEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_TicaretUI.Models
{
    public class MyProductModelView
    {
        public int myProductID { get; set; }
        public string name { get; set; }
        public string Description { get; set; }
        public string ımage { get; set; }
        public double Price { get; set; }
        public int piece { get; set; }
        public string category { get; set; }
        public List<Product> myProducts { get; set; }
        public List<Image> myImages { get; set; }
        public List<Comment> comments { get; set; }
        public int questıonProductID { get; set; }
        public string senderemail { get; set; }
        public string About { get; set; }
        public int commentproductıd { get; set; }
        public string comment { get; set; }
        public string Customerusername { get; set; }
        public string Customeremail { get; set; }
    }
}
