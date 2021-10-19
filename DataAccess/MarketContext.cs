using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataAccess
{
    public class MarketContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=B166ER;Database=Dream;Trusted_Connection=true;");
        }

        DbSet<Product> Products { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<SalesInfo> SalesInfos { get; set; }
        DbSet<Cart> Carts { get; set; }



    }
}
