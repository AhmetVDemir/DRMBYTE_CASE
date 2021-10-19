using DataAccess.Repostories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        public IProductRepostory ProductRepostory { get; }

        public IUserRepostory UserRepostory { get; }

        public ICartRepostory CartRepostory { get; }

        public ISalesInfoRepostory SalesInfoRepostory { get; }

        public int Complate();
    }
}
