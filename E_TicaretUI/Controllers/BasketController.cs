using E_TicaretBLL.Abstract;
using E_TicaretDAL.Migrations;
using E_TicaretEntity;
using E_TicaretUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace E_TicaretUI.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly UserManager<Users> _userManager;
        private readonly ProductService _productService;
        private readonly UIBasketService _uibasketService;
        private readonly UIBasket_2Service _uibasket_2Service;

        public BasketController(UserManager<Users> userManager,
            SellerService sellerService, ProductService productService,UIBasketService uIBasketService,
            UIBasket_2Service uibasket_2Service)
        {
            _userManager = userManager;
            _uibasketService = uIBasketService;    
            _productService = productService;
            _uibasket_2Service = uibasket_2Service;
        }
        [HttpGet]
        public async Task <IActionResult> Basket()
        {

            if (User.Identity.IsAuthenticated)
            {
                BasketModelView basketModelView = new BasketModelView();
                var user= await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    var basket=_uibasketService.GetAll(i=>i.UsersId==user.Id);
                    var basket2=_uibasket_2Service.Fınd(i=>i.UsersId==user.Id);

                    if (basket2 != null)
                    {
                        ViewBag.totalproductprice = basket2.totalproductprice;
                        ViewBag.totalprice = basket2.totalprice;
                        ViewBag.cargo=basket2.cargo;
                        ViewBag.productcount = basket2.productcount;
                    }

                    if(basket != null)
                    {

                        ViewBag.Basket= basket
                            .Where(i => !string.IsNullOrEmpty(i.productımage) &&
                            !string.IsNullOrEmpty(i.prductname) &&
                            i.productprice > 0 &&
                            i.productpiece > 0).ToList();
                           
                    }

                    var BasketPrice = _uibasketService.Fınd(i => i.UsersId == user.Id);
                    if(BasketPrice != null)
                    {
                        ViewBag.BasketPrice = BasketPrice.productprice;
                        ViewBag.Basketpiece = BasketPrice.productpiece;

                    }
                }
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> BasketAdd(string productname)
        {
            if (User.Identity.IsAuthenticated)
            {
                double cargopercentage = 0.01;
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var product = _productService.Fınd(i => i.name == productname);
                if (product != null)
                {
                    var uıbasket = _uibasketService.Fınd(i => i.UsersId == user.Id&&i.prductname==productname);
                    if (uıbasket == null)
                    {
                        UIBasket basket = new UIBasket();
                        //basket.Users = new Users();
                        basket.UsersId = user.Id;
                        basket.prductname = product.name;
                        basket.productımage = product.ımage;
                        basket.productprice = product.Price;
                        basket.productpiece = 1;

                        var uıtotal = _uibasket_2Service.Fınd(i => i.UsersId == user.Id);

                        if (uıtotal == null)
                        {
                            UIBasket_2 basket_2 = new UIBasket_2();

                            //basket_2.Users = new Users();
                            basket_2.UsersId = user.Id;
                            basket_2.totalproductprice = product.Price;
                            basket_2.cargo = product.Price * cargopercentage;
                            basket_2.totalprice = basket_2.totalproductprice + basket_2.cargo;
                            basket_2.productcount += 1;

                            _uibasket_2Service.Insert(basket_2);
                            _uibasketService.Insert(basket);

                            return RedirectToAction("Basket", "Basket");
                        }

                        if (uıtotal != null)
                        {

                            
                            uıtotal.totalproductprice = uıtotal.totalproductprice + product.Price;
                            uıtotal.cargo = uıtotal.cargo + product.Price * cargopercentage;
                            uıtotal.totalprice = uıtotal.totalproductprice + uıtotal.cargo;
                            uıtotal.productcount += 1;

                            _uibasket_2Service.Update(uıtotal);
                            _uibasketService.Insert(basket);

                            return RedirectToAction("Basket", "Basket");
                        }

                    }
                    else if (uıbasket != null&&uıbasket.prductname==productname)
                    {
                        uıbasket.productpiece += 1;
                        var uıbasket2=_uibasket_2Service.Fınd(i=>i.UsersId==user.Id);
                        if(uıbasket2 != null)
                        {
                            uıbasket2.totalproductprice=uıbasket2.totalproductprice+product.Price;
                            uıbasket2.cargo=uıbasket2.totalproductprice*cargopercentage;
                            uıbasket2.totalprice = uıbasket2.totalproductprice + uıbasket2.cargo;
                            uıbasket2.productcount += 1;
                            _uibasket_2Service.Update(uıbasket2);
                        }
                        _uibasketService.Update(uıbasket);
                        return RedirectToAction("Basket","Basket");
                    }
                    //else if (uıbasket != null)
                    //{
                    //    UIBasket basket = new UIBasket();
                    //    basket.UsersId = user.Id;
                    //    basket.prductname = product.name;
                    //    basket.productımage = product.ımage;
                    //    basket.productprice = product.Price;
                    //    basket.productpiece = 1;


                    //    var uıtotal = _uibasket_2Service.Fınd(i => i.UsersId == user.Id);

                    //    if (uıtotal == null)
                    //    {
                    //        UIBasket_2 basket_2 = new UIBasket_2();
                    //        basket_2.UsersId = user.Id;
                    //        basket_2.totalproductprice = product.Price;
                    //        basket_2.cargo = product.Price * cargopercentage;
                    //        basket_2.totalprice = basket_2.totalproductprice + basket_2.cargo;
                    //        basket_2.productcount += 1;

                    //        _uibasket_2Service.Insert(basket_2);
                    //        _uibasketService.Insert(basket);

                    //        return RedirectToAction("Basket", "Basket");
                    //    }

                        
                    //    if (uıtotal != null)
                    //    {

                    //        uıtotal.UsersId = user.Id;
                    //        uıtotal.totalproductprice = uıtotal.totalproductprice + product.Price;
                    //        uıtotal.cargo = uıtotal.cargo + product.Price * cargopercentage;
                    //        uıtotal.totalprice = uıtotal.totalproductprice + uıtotal.cargo;
                    //        uıtotal.productcount += 1;

                    //        _uibasket_2Service.Update(uıtotal);
                    //        _uibasketService.Insert(basket);

                    //        return RedirectToAction("Basket", "Basket");
                    //    }
                    //}
                }

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string productName)
        {
            if (User.Identity.IsAuthenticated)
            {
                double cargoPercentage = 0.01;
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                if (user != null)
                {
                    var basketProduct = _uibasketService.Fınd(i => i.prductname == productName);

                    if (basketProduct != null)
                    {
                        for (int i = basketProduct.productpiece; i >= 1; i--)
                        {
                            basketProduct.productpiece -= 1;

                            var basketProductTotal = _uibasket_2Service.Fınd(i => i.UsersId == user.Id);

                            if (basketProductTotal != null)
                            {
                                basketProductTotal.totalproductprice -= basketProduct.productprice;
                                basketProductTotal.cargo = basketProductTotal.totalproductprice * cargoPercentage;
                                basketProductTotal.totalprice = basketProductTotal.totalproductprice + basketProductTotal.cargo;
                                basketProductTotal.productcount -= 1;

                                _uibasket_2Service.Update(basketProductTotal);

                                if (basketProduct.productpiece == 0)
                                {
                                    
                                    _uibasketService.Deleted(basketProduct);
                                    
                                }
                                
                            }
                        }
                        return RedirectToAction("Basket", "Basket");

                    }
                }
            }

            return View();
        }
        [HttpGet]
        public async Task <IActionResult> Add_Decrease(string productname,double productprice)
        {
            if(User.Identity.IsAuthenticated)
            {
                var user= await _userManager.FindByNameAsync(User.Identity.Name);
                if (user != null)
                {
                    var uıproduct=_uibasketService.Fınd(i=>i.prductname==productname);
                    if(uıproduct!=null) 
                    {
                        double cargopercentage = 0.01;
                        uıproduct.productpiece += 1;
                        var uıbasket2 = _uibasket_2Service.Fınd(i => i.UsersId == user.Id);
                        if (uıbasket2 != null)
                        {
                            uıbasket2.totalproductprice = uıbasket2.totalproductprice + uıproduct.productprice;
                            uıbasket2.cargo = uıbasket2.totalproductprice * cargopercentage;
                            uıbasket2.totalprice = uıbasket2.totalproductprice + uıbasket2.cargo;
                            uıbasket2.productcount += 1;
                            _uibasket_2Service.Update(uıbasket2);
                        }
                        _uibasketService.Update(uıproduct);
                        return RedirectToAction("Basket", "Basket");
                    }
                    var uıproduct2 = _uibasketService.Fınd(i => i.productprice == productprice);
                    if (uıproduct2 != null)
                    {
                        double cargopercentage = 0.01;
                        if (uıproduct2.productpiece != 1)
                        {
                            uıproduct2.productpiece -= 1;
                            var uıbasket2 = _uibasket_2Service.Fınd(i => i.UsersId == user.Id);
                            if (uıbasket2 != null)
                            {
                                uıbasket2.totalproductprice = uıbasket2.totalproductprice - uıproduct2.productprice;
                                uıbasket2.cargo = uıbasket2.totalproductprice * cargopercentage;
                                uıbasket2.totalprice = uıbasket2.totalproductprice + uıbasket2.cargo;
                                uıbasket2.productcount -= 1;
                                _uibasket_2Service.Update(uıbasket2);
                            }
                            _uibasketService.Update(uıproduct2);
                            return RedirectToAction("Basket", "Basket");
                        }
                        if(uıproduct2.productpiece == 1)
                        {
                            
                            var uıbasket2 = _uibasket_2Service.Fınd(i => i.UsersId == user.Id);
                            if (uıbasket2 != null)
                            {
                                uıbasket2.totalproductprice = uıbasket2.totalproductprice - uıproduct2.productprice;
                                uıbasket2.cargo = uıbasket2.totalproductprice * cargopercentage;
                                uıbasket2.totalprice = uıbasket2.totalproductprice + uıbasket2.cargo;
                                uıbasket2.productcount -= 1;
                                _uibasket_2Service.Update(uıbasket2);
                            }
                            _uibasketService.Deleted(uıproduct2);
                            return RedirectToAction("Basket", "Basket");
                        }
                    }
                }
            }
            return RedirectToAction("Basket", "Basket");
        }
    }
}
