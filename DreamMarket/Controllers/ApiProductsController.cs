using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DreamMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiProductsController : ControllerBase
    {
        UnitOfWork UOW;
        public ApiProductsController()
        {
            UOW = new UnitOfWork(new MarketContext());
        }
        ~ApiProductsController()
        {
            UOW.Dispose();
        }

        [HttpGet]
        public List<Product> Get()
        {
            List<Product> dene = new List<Product>();
            dene = UOW.ProductRepostory.GetAll().ToList<Product>();
            UOW.Dispose();
            return dene;
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return UOW.ProductRepostory.GetById(id);
        }

        [HttpPost]
        public void Post(Product product)
        {
            UOW.ProductRepostory.Add(product);
            UOW.Complate();
            UOW.Dispose();
        }


    }
}
