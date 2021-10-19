using DataAccess.Repostories.Abstract;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repostories.Concrete
{
    public class CartRepostory : Repostory<Cart>,ICartRepostory
    {
        public CartRepostory(MarketContext context):base(context)
        {

        }
    }
}
