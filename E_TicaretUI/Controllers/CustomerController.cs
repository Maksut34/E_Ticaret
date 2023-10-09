using E_TicaretBLL.Abstract;
using E_TicaretEntity;
using E_TicaretUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretUI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly UserManager<Users> _userManager;
        private readonly SellerService _sellerService;
        private readonly ProductService _productService;
        public CustomerController(UserManager<Users> userManager,
            SellerService sellerService, ProductService productService)
        {
            _userManager = userManager;
            _sellerService = sellerService;
            _productService = productService;
        }
        [HttpGet]
        public IActionResult Customer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Customer(CustomerModelView customerModel)
        {
            return View();
        }
    }
}
