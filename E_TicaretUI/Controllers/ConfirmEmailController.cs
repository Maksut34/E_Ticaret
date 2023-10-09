using E_TicaretEntity;
using E_TicaretUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_TicaretUI.Controllers
{
    public class ConfirmEmailController : Controller
    {
        private readonly UserManager<Users> _users;
       
        public ConfirmEmailController(UserManager<Users> user)
        {
            _users = user;
        }
        [HttpGet]
        public IActionResult ConfirmEmail()
        {
            var value = TempData["Email"];
            var ID = TempData["ID"];
            ViewBag.ID = ID;
            ViewBag.Email = value;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmail confirmEmail)
        {
            Users u = new Users();
            u.Id = confirmEmail.ID;
            var ıd = await _users.FindByIdAsync(u.Id.ToString());
            if (ıd.ConfirmEmailCode == confirmEmail.ConfirmEmailCode)
            {
                ıd.EmailConfirmed = true;

                await _users.UpdateAsync(ıd);

                return RedirectToAction("Tebrikler", "ConfirmEmail");
            }
            else
            {
                ModelState.AddModelError("", "Yanlış code!");
            }

            return View();
        }
        public IActionResult Tebrikler()
        {
            return View();
        }
    }
}
