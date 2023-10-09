using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretEntity
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        public string name { get; set; }
        public string Description { get; set; }
        public string ımage { get; set; }
        public List<Image> Image { get; set; }
        public double Price { get; set; }
        public int piece { get; set; }
        public string category { get; set; }
        [ForeignKey("Seller")]
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
        public List<Comment> Comment { get; set; }
        public List<Question> Question { get; set; }
    }
}
