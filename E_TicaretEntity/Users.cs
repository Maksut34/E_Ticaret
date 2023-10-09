using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_TicaretEntity
{
    public class Users:IdentityUser<int>
    {
        public string ConfirmPassword { get; set; }
        public int ConfirmEmailCode { get; set; }
        public bool IsSeller { get; set; }
        public List<UIBasket> UIBasket { get; set; }
    }
}
