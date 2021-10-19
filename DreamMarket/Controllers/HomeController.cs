
using DataAccess;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DreamMarket.Controllers
{
    public class HomeController : Controller
    {
       
        
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormCollection veriler)
        {

            UnitOfWork uow = new UnitOfWork(new MarketContext());

            if ((uow.UserRepostory.GetById(1).Email == veriler["Email"].ToString()) &&(uow.UserRepostory.GetById(1).Password == veriler["Password"].ToString()))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, "Email")
                };

                var kimlik = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal cp = new ClaimsPrincipal(kimlik);
                await HttpContext.SignInAsync(cp);

                return RedirectToAction("Index", "Home", new { area = "UserInterface" });
            }
            else
            {
                return RedirectToAction("AccesDenied","Home");
            }

        }

        public IActionResult AccesDenied()
        {
            return View();
        }



    }
}
