using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product : IEntity
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int UnitPrice { get; set; }

        public int UnitInStock { get; set; }

        public string ProductType { get; set; }

        public string Brand { get; set; }
    }
}
