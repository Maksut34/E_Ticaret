using E_TicaretBLL.Abstract;
using E_TicaretEntity;
using E_TicaretUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using MimeKit;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Globalization;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace E_TicaretUI.Controllers
{
    
    [AutoValidateAntiforgeryToken]
    [Authorize]

    public class SellerController : Controller
    {
        Image ımage = new Image();
        private readonly UserManager<Users> _userManager;
        private readonly SellerService _sellerService;
        private readonly ProductService _productService;
        private readonly İmageService _imageService;
        private readonly QuestıonService _questıonService;
        private readonly CommentService _commentService;
        public SellerController(UserManager<Users> userManager,SellerService sellerService, ProductService productService,
            İmageService imageService,QuestıonService questıonService,CommentService commentService)
        {
            _userManager = userManager;
            _sellerService = sellerService;
            _productService = productService;
            _imageService = imageService;
            _questıonService = questıonService;
            _commentService = commentService;
        }
        Product image=new Product();
        [HttpGet]
        public IActionResult Seller()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Seller(SellerModelView sellerMoldel)
        {
            if(User.Identity.IsAuthenticated)
            {
                if(ModelState.IsValid)
                {
                    var user = await _userManager.FindByNameAsync(User.Identity.Name);
                    if (user != null)
                    {
                        Seller seller = new Seller()
                        {
                            UsersID = user.Id,
                            CompanyName=sellerMoldel.CompanyName,
                            CompanyType=sellerMoldel.CompanyType,
                            TaxIdentificationNumber=sellerMoldel.TaxIdentificationNumber,
                            BusinessAddress=sellerMoldel.BusinessAddress,
                            BankName=sellerMoldel.BankName,
                            IBAN=sellerMoldel.IBAN

                        };

                        _sellerService.Insert(seller);
                        return RedirectToAction("Toinform", "Seller");
                    }
                }
            }
            return View();
        }
        public IActionResult Toinform()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Products()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Products(ProductsModelView productsModel)
        {
            if (User.Identity.IsAuthenticated)
            {
                var users = await _userManager.FindByNameAsync(User.Identity.Name);
                if (users != null)
                {
                    var serllers = _sellerService.Fınd(i => i.UsersID == users.Id);

                    if (serllers != null)
                    {
                        if (ModelState.IsValid)
                        {
                            var extension = Path.GetExtension(productsModel.ımage.FileName);
                            var newImageName = Guid.NewGuid() + extension;
                            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/lib/img/", newImageName);
                            var stream = new FileStream(location, FileMode.Create);
                            productsModel.ımage.CopyTo(stream);

                            // Ürün fiyatını ayarlamak için önce kullanıcının girdiği metni uygun bir şekilde dönüştürün
                            // Virgül veya nokta kullanımına izin veriliyorsa, aşağıdaki kodu kullanabilirsiniz
                            double price;
                            if (double.TryParse(productsModel.Price.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out price))
                            {
                                // Veritabanına ürün bilgisini kaydetme işlemi
                                Product seller = new Product()
                                {
                                    SellerId = serllers.SellerId,
                                    name = productsModel.name,
                                    ımage = newImageName,
                                    Price = price, // Ürün fiyatını ayarlayın
                                    piece = productsModel.piece,
                                    category = productsModel.category,
                                    Description = productsModel.Description
                                };
                                _productService.Insert(seller);

                                return RedirectToAction("Profile", "Account");
                            }
                            else
                            {
                                // Fiyat dönüşümü başarısız oldu
                                ModelState.AddModelError("Price", "Geçersiz fiyat formatı.");
                            }
                        }
                    }
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Image(string productname)
        {
            
            ViewBag.product = productname;
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Image(ProductImageModelView ımageModelView)
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user.IsSeller == true)
            {
                if (ModelState.IsValid)
                {
                    var product = _productService.Fınd(i => i.name == ımageModelView.name);
                    if (product != null)
                    {
                        var ımj = _imageService.Find(i => i.ProductId == product.ID);
                        if (ımj == null)
                        {
                            var extension = Path.GetExtension(ımageModelView.ımage.FileName);
                            var newimagename = Guid.NewGuid() + extension;
                            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/lib/img/", newimagename);
                            var stream = new FileStream(location, FileMode.Create);
                            ımageModelView.ımage.CopyTo(stream);
                            image.ımage = newimagename;


                            ımage.ProductId = product.ID;
                            ımage.ımageUrl = newimagename;

                            _imageService.Insert(ımage);

                            return RedirectToAction("MyProducts", "Seller");
                        }
                        else
                        {
                            var extension = Path.GetExtension(ımageModelView.ımage.FileName);
                            var newimagename = Guid.NewGuid() + extension;
                            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/lib/img/", newimagename);
                            var stream = new FileStream(location, FileMode.Create);
                            ımageModelView.ımage.CopyTo(stream);
                            image.ımage = newimagename;


                            Image ımage1 = new Image()
                            {
                                ProductId = product.ID,
                                ımageUrl = newimagename
                            };

                            _imageService.Insert(ımage1);

                            return RedirectToAction("MyProducts", "Seller");
                        }

                    }

                }

            }
                return View();
        }
        [HttpGet]
        public async Task<IActionResult> MyProducts()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user.IsSeller == true)
                {
                    var seller = _sellerService.Fınd(i=>i.UsersID==user.Id);
                    if (seller != null)
                    {
                        var product = _productService.Lıst(i => i.SellerId == seller.SellerId);

                        if (product != null)
                        {
                            MyProductModelView model = new MyProductModelView();
                            model.myProducts = product
                                .Where(p =>
                                    !string.IsNullOrEmpty(p.ımage) &&
                                    !string.IsNullOrEmpty(p.name) &&
                                    p.piece > 0 && // int değeri kontrol ediyoruz
                                    !string.IsNullOrEmpty(p.category) &&
                                    !string.IsNullOrEmpty(p.Description) &&
                                    p.Price>0 // decimal değeri kontrol ediyoruz
                                )
                                .ToList();


                            return View(model);
                        }
                        return View();
                    }
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Detail(int productId)
        {
            
            var product = _productService.Fınd(i=>i.ID==productId);
            var imj=_imageService.getAll().Where(i=>i.ProductId == productId);
            var comment = _commentService.getAll();

            if (product == null)
            {
                // Ürün bulunamadıysa uygun bir işlem yapabilirsiniz, örneğin hata sayfasına yönlendirme yapabilirsiniz.
                return RedirectToAction("Error");
            }

            // Ürünü detaylar sayfasında göstermek için Model'e ekle
            MyProductModelView model = new MyProductModelView();
            model.myProductID = product.ID;
            model.name = product.name;
            model.ımage = product.ımage;
            model.piece = product.piece;
            model.category = product.category;
            model.Description = product.Description;
            model.Price = product.Price;
            model.myImages= imj
                .Where(i=>!string.IsNullOrEmpty(i.ımageUrl))
                .ToList();
            model.comments = comment
                .Where(i => !string.IsNullOrEmpty(i.comment) && !string.IsNullOrEmpty(i.Customerusername))
                .Take(10).ToList();
            ViewBag.product = productId;

            return View(model);
            
        }
        [HttpPost]
        public async Task<IActionResult> Detail(MyProductModelView questıon)
        {
            try
            {
                if (questıon.questıonProductID != null&&questıon.senderemail!=null&&questıon.About!=null)
                {
                    var prduct = _productService.Fınd(i => i.ID == questıon.questıonProductID);
                    if (prduct != null)
                    {
                        var seller = _sellerService.Fınd(i => i.SellerId == prduct.SellerId);
                        if (seller != null)
                        {
                            int ID = seller.SellerId;
                            var user = await _userManager.FindByIdAsync(ID.ToString());
                            if (user != null)
                            {
                                Question question = new Question()
                                {
                                    ProductId = prduct.ID,
                                    senderemail = questıon.senderemail,
                                    about = questıon.About
                                };

                                _questıonService.Insert(question);

                                string productname = prduct.name;

                                MimeMessage mimeMessage = new MimeMessage();
                                MailboxAddress mailboxAddressfrom = new MailboxAddress("Müşteri", question.senderemail);
                                MailboxAddress mailboxAddressto = new MailboxAddress("Satıcı", user.Email);

                                mimeMessage.From.Add(mailboxAddressfrom);
                                mimeMessage.To.Add(mailboxAddressto);

                                var bodybuilder = new BodyBuilder();
                                bodybuilder.TextBody = productname + "" + "hakkında soru!:" + question.about;
                                mimeMessage.Body = bodybuilder.ToMessageBody();

                                mimeMessage.Subject = "Müşteri sorusu!";

                                using (var client = new MailKit.Net.Smtp.SmtpClient())
                                {
                                    client.Connect("smtp.gmail.com", 587, false);
                                    client.Authenticate("mesut34ozdemir34@gmail.com", "vzqcdswkgcoqdxjj");
                                    client.Send(mimeMessage);
                                    client.Disconnect(true);
                                }

                                return RedirectToAction("Detail", "Seller");

                            }
                        }
                    }
                }
                else if (questıon.commentproductıd!=null&&questıon.Customeremail!=null&&questıon.comment!=null)
                {
                    var product = _productService.Fınd(i => i.ID == questıon.commentproductıd);

                    if(product!=null)
                    {
                        Comment comments = new Comment()
                        {
                            ProductId = product.ID,
                            Customeremail=questıon.Customeremail,
                            Customerusername=questıon.Customerusername,
                            comment=questıon.comment
                        };

                        _commentService.Insert(comments);

                        return RedirectToAction("Detail", "Seller");
                    }
                }

                
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(ViewBag.ErrorMessage);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(string productname)
        {
            var product = _productService.Fınd(i => i.name == productname);
            if (product != null)
            {
                var images = _imageService.Find(i => i.ProductId == product.ID);
                if (images != null)
                {
  
                    foreach (var image in images)
                    {
                        _imageService.Deleted(image);
                    }
                }

                
                _productService.Deleted(product);
            }

            return RedirectToAction("MyProducts", "Seller");
        }
    }
}
