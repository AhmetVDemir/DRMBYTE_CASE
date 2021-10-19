using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DreamMarket.Areas.UserInterface.Controllers
{
    [Area("UserInterface")]
    public class HomeController : Controller
    {

        [Authorize]
        public IActionResult Index()
        {
            return RedirectToAction("GetAllProduct", "Urunler");
        }

        
    }
}
