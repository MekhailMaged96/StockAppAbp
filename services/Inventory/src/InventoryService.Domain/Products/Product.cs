using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace InventoryService.Products
{
    public class Product :AggregateRoot<Guid>
    {
        public string Name { get; set; }
        public int Quantity { get; set; }      
    }
}
