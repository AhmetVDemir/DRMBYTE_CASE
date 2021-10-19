
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamMarket.Areas.UserInterface.Controllers
{
    [Area("UserInterface")]
    public class UrunlerController : Controller
    {
        UnitOfWork UOW;
        public UrunlerController()
        {
            UOW = new UnitOfWork(new MarketContext());
            
        }

        #region GetOperations

        [Authorize]
        public IActionResult GetAllProduct()
        {

            
            List<Product> gelenSonuc;
            gelenSonuc = UOW.ProductRepostory.GetAll().ToList<Product>();
            UOW.Dispose();
            ViewBag.Sonuclar = gelenSonuc;
            return View();
        }

        #endregion

        #region AddOpetations

        [HttpGet]
        [Authorize]
        public IActionResult AddProduct()
        {

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddProduct(Product product)
        {
            UOW.ProductRepostory.Add(product);
            UOW.Complate();
            UOW.Dispose();
            
            return View("AddSuccess");
        }
        #endregion

        #region DeleteOperations

        [Authorize]
        public IActionResult DelProduct(int Id)
        {
            UOW.ProductRepostory.Delete(Id);
            UOW.Complate();
            UOW.Dispose();
            return View();
        }

        #endregion

        #region UpdateOperation

        [Authorize]
        [HttpPost]
        public IActionResult UpdateProduct(int ProductId)
        {
            Product gelenSonuc;
            gelenSonuc = UOW.ProductRepostory.GetById(ProductId);
            ViewBag.Sonuc = gelenSonuc;
            UOW.Complate();
            UOW.Dispose();
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult UpdateSuccess(Product product)
        {
            UOW.ProductRepostory.Update(product);
            UOW.Complate();
            UOW.Dispose();

            return View();
        }


        #endregion

        #region CartOperation
        
        [Authorize]
        public IActionResult Cart(int Id)
        {
           /*
            * 1 carta bağlı başka bir ürün listesi yap cart id tek olsun
            * 2 carta aynı kişide ki product id yi 1 deki listeye koy sadece aynı ürünün tekrar sayısının yazsın
            * 3 toplam fiyatı satış taplosuna koy
            * 4 cart a bağlı liste tablosunda ki ürünlerin sayısı kadar db den eksilt yada artır 
            * 5
            */

            Cart tmpCart = new Cart();
            tmpCart.ProductId = Id;
            if (tmpCart.Quantity == null)
                tmpCart.Quantity = 0;
            tmpCart.Quantity += 1;
            if (tmpCart.TotalPrice == null)
                tmpCart.TotalPrice = 0;
            tmpCart.TotalPrice += UOW.ProductRepostory.GetById(Id).UnitPrice;
            tmpCart.UserId = 1;

            UOW.CartRepostory.Add(tmpCart);
            UOW.Complate();
            UOW.Dispose();

            return RedirectToAction("GetAllProduct");
        }

        #endregion

        #region SalesOperations

        [Authorize]
        public IActionResult SalesOp()
        {
            List<Cart> Urunler = UOW.CartRepostory.GetAll().Where(x => x.UserId == 1).ToList<Cart>();
            var listOfCart = Urunler;
            ViewBag.KartListesi = listOfCart;
            UOW.Dispose();
            
            return View();
        }

        [Authorize]
        public IActionResult Cikar(int Id)
        {
            UOW.CartRepostory.Delete(Id);
            UOW.Complate();
            UOW.Dispose();

            return RedirectToAction("SalesOp","Urunler");
        }

        [HttpPost]
        [Authorize]
        public IActionResult Tamamla(string Odeme)
        {
            SalesInfo siTemp = new SalesInfo();
            siTemp.PriceType = Odeme;
            siTemp.SalesDate = DateTime.Now;
            siTemp.CartId = 0;

            List<Cart> sepetData = new List<Cart>();
            sepetData = UOW.CartRepostory.GetAll().Where(x => x.UserId == 1).ToList<Cart>();
            int toplam = 0;
            foreach (var item in sepetData)
            {
                toplam += item.TotalPrice;

            }

            siTemp.ToralPrice = toplam;

            UOW.SalesInfoRepostory.Add(siTemp);
            UOW.Complate();
            UOW.Dispose();

            return View("SalesSuccess");
        }

        #endregion


    }
}
