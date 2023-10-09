using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretEntity
{
    public class UIBasket_2
    {
        [Key]
        public int uuıbasket_2_Id { get; set; }
        public double totalproductprice { get; set; }
        public double totalprice { get; set; }
        public double cargo { get; set; }
        public int productcount { get; set; }
        [ForeignKey("Users")]
        public int UsersId { get; set; }
        public Users Users { get; set; }
    }
}
