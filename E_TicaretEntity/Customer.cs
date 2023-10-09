using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretEntity
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string name_surname { get; set; }
        public string cardnumber { get; set; }
        public string Address { get; set; }
        public string KartTarihiAy { get; set; }
        public string KartTarihiYıl { get; set; }
        public string KartCVC { get; set; }
        public int UsersID { get; set; }
        public Users Users { get; set; }
    }
}
