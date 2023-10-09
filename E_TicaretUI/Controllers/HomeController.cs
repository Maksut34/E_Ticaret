using E_TicaretBLL.Abstract;
using E_TicaretUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_TicaretUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;
        public HomeController(ProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Wellcome()
        {
            return View();
        }
        public IActionResult Home()
        {

            var product = _productService.getAll();

            if (product != null)
            {
                Products model = new Products();
                model.myProducts = product
                    .Where(p =>
                        !string.IsNullOrEmpty(p.ımage) &&
                        !string.IsNullOrEmpty(p.name) &&
                        p.piece > 0 && // int değeri kontrol ediyoruz
                        !string.IsNullOrEmpty(p.category) &&
                        !string.IsNullOrEmpty(p.Description) &&
                        p.Price > 0 // decimal değeri kontrol ediyoruz
                    ).Take(10)
                    .ToList();


                return View(model);
            }
            return View();
        }
    }
}