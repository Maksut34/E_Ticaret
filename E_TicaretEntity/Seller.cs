using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretEntity
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }


        public string CompanyName { get; set; }

        public string CompanyType { get; set; }


        public string TaxIdentificationNumber { get; set; }


        public string BusinessAddress { get; set; }


        public string BankName { get; set; }


        public string IBAN { get; set; }
        [ForeignKey("Users")]
        public int UsersID { get; set; }
        public Users Users { get; set; }

        public List<Product> Product { get; set; }
    }
}
