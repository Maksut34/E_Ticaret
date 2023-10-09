using System.ComponentModel.DataAnnotations;

namespace E_TicaretUI.Models
{
    public class AccountLoginView
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
