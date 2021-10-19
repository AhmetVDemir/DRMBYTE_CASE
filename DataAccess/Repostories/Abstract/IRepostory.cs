using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repostories.Abstract
{
    public interface IRepostory<TEntity> where TEntity:class
    {
        //For GenericRepostory DP Base
        TEntity GetById(int id);
        List<TEntity> GetAll();
        void Add(TEntity entity);
        void Delete(int Id);

        void Update(TEntity entity);

    }
}
