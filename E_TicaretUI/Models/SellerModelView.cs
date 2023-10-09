using System.ComponentModel.DataAnnotations;

namespace E_TicaretUI.Models
{
    public class SellerModelView
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyType { get; set; }
        [Required]
        public string TaxIdentificationNumber { get; set; }
        [Required]
        public string BusinessAddress { get; set; }
        [Required]
        public string BankName { get; set; }
        public string IBAN { get; set; }

    }
}
