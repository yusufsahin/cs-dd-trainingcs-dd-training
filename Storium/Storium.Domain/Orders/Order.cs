using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storium.Domain.Orders
{
    public sealed class Order
    {
        public Guid Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
