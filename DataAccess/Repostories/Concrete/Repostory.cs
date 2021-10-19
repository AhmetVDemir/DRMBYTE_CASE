using DataAccess.Repostories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repostories.Concrete
{
    public class Repostory<T> : IRepostory<T> where T:class
    {
        protected DbContext _context;
        private DbSet<T> _dbset;
        public Repostory(DbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }
        

        #region Implementation
        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public void Delete(int Id)
        {
            _dbset.Remove(GetById(Id));
        }

        public List<T> GetAll()
        {
            return _dbset.ToList();
        }

        public T GetById(int id)
        {
            return _dbset.Find(id);
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }
        #endregion
    }
}
