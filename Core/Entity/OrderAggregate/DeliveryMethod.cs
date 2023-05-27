using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entity.OrderAggregate
{
    public class DeliveryMethod : BaseEntity
    {
        public string  ShortName { get; set; }
        public string  DeliveryTime { get; set; }
        public string  Descripton { get; set; }
        public decimal Price { get; set; }
        
    }
}