using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SalesInfo:IEntity
    {
        public int Id { get; set; }

        public int CartId { get; set; }

        public int ToralPrice { get; set; }

        public string PriceType { get; set; }

        public DateTime SalesDate { get; set; }


    }
}
