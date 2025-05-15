using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace OrderingService.Orders
{
    public class Order : AggregateRoot<Guid>
    {
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public string Status { get; private set; }

        private Order() { } // EF Core requires a parameterless constructor

        public Order(Guid id, Guid productId, string productName, int quantity, decimal price)
        {
            Id = id;
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            Status = "Pending"; // Default status
        }

        public void UpdateStatus(string status)
        {
            Status = status;
        }
    }

}
