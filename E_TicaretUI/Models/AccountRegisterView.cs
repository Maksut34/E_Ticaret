using System.ComponentModel.DataAnnotations;

namespace E_TicaretUI.Models
{
    public class AccountRegisterView
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string Username { get; set; }

    }
}
