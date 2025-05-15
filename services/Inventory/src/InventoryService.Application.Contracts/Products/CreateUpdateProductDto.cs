using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Products
{
    public class CreateUpdateProductDto
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
