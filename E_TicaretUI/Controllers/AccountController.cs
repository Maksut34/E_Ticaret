using E_TicaretEntity;
using E_TicaretUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace E_TicaretUI.Controllers
{
    public class AccountController : Controller
    {
        Random random = new Random();
        private readonly SignInManager<Users> _signInManager;
        private readonly UserManager<Users> _userManager;
        public AccountController(UserManager<Users> userManager, SignInManager<Users> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Register(AccountRegisterView accountRegister)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Bütün alanları doldurmak zorunludur!");
                }
                Users user = new Users()
                {
                    UserName = accountRegister.Username,
                    Email = accountRegister.Email,
                    ConfirmPassword = accountRegister.ConfirmPassword,
                    ConfirmEmailCode = random.Next(100, 999)
                };
                var resault = await _userManager.CreateAsync(user, accountRegister.Password);

                if (resault.Succeeded)
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressfrom = new MailboxAddress("Admin", "mesut34ozdemir34@gmail.com");
                    MailboxAddress mailboxAddressto = new MailboxAddress("User", user.Email);

                    mimeMessage.From.Add(mailboxAddressfrom);
                    mimeMessage.To.Add(mailboxAddressto);

                    var bodybuilder = new BodyBuilder();
                    bodybuilder.TextBody = "Onay kodunuz!:" + user.ConfirmEmailCode;
                    mimeMessage.Body = bodybuilder.ToMessageBody();

                    mimeMessage.Subject = "Kazanç Onay kodunuz";

                    using (var client = new MailKit.Net.Smtp.SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("mesut34ozdemir34@gmail.com", "vzqcdswkgcoqdxjj");
                        client.Send(mimeMessage);
                        client.Disconnect(true);
                    }

                    TempData["Email"] = "Kodun gönderildiği email!:" + user.Email;
                    TempData["ID"] = user.Id;

                    return RedirectToAction("ConfirmEmail", "ConfirmEmail");
                }
               
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage=ex.Message;
                return View(ViewBag.ErrorMessage);
            }
        }
        [AutoValidateAntiforgeryToken]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Login(AccountLoginView loginView, Users u)
        {

            var users = await _userManager.FindByEmailAsync(u.Email);

            var user = await _signInManager.PasswordSignInAsync(users.UserName,loginView.Password,false,true);

            if (user == null)
            {
                ModelState.AddModelError("", "Yanlış email yada şifre!");
            }
            else
            {
                if (user.Succeeded)
                {

                    if (users.EmailConfirmed == true)
                    {
                        return RedirectToAction("Home", "Home");

                    }
                    else
                    {
                        ModelState.AddModelError("", "Görünüşe göre email doğrulanmamış! Lütfen önce emailinizi gelen kod ile doğrulayın!");
                    }
                }
            }
            return View();
        }
        [Authorize]
        [HttpGet]
        public async Task <IActionResult> Profile()
        {
            if (User.Identity.IsAuthenticated)
            {
                var result = await _userManager.FindByNameAsync(User.Identity.Name);
                if (result != null)
                {
                    ViewBag.satcımı = result.IsSeller;

                    ViewBag.name = result.UserName;
                }
            }
            return View();
        }
    }
}
