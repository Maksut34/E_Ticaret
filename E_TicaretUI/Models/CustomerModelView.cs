using System.ComponentModel.DataAnnotations;

namespace E_TicaretUI.Models
{
    public class CustomerModelView
    {
        [Required]
        public string name_surname { get; set; }
        [Required]
        public string cardnumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string KartTarihiAy { get; set; }
        [Required]
        public string KartTarihiYıl { get; set; }
        [Required]
        public string KartCVC { get; set; }
    }
}
