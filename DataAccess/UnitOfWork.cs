using DataAccess.Repostories.Abstract;
using DataAccess.Repostories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private MarketContext _marketContext;
        public UnitOfWork(MarketContext context)
        {
            _marketContext = context;
            ProductRepostory = new ProductRepostory(_marketContext);
            UserRepostory = new UserRepostory(_marketContext);
            CartRepostory = new CartRepostory(_marketContext);
            SalesInfoRepostory = new SalesInfoRepostory(_marketContext);
        }

        public IProductRepostory ProductRepostory { get; private set; }

        public IUserRepostory UserRepostory { get; private set; }

        public ICartRepostory CartRepostory { get; private set; }

        public ISalesInfoRepostory SalesInfoRepostory { get; private set; }

        public int Complate()
        {
            return _marketContext.SaveChanges();
        }

        public void Dispose()
        {
            _marketContext.Dispose();
        }
    }
}
