using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretEntity
{
    public class UIBasket
    {
        [Key]
        public int uıbasketıd { get; set; }
        public string productımage { get; set; }
        public string prductname { get; set; }
        public int productpiece { get; set; }
        public double productprice { get; set; }
        [ForeignKey("Users")]
        public int UsersId { get; set; }
        public Users Users { get; set; }

    }
}
