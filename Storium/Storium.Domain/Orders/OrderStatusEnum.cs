using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storium.Domain.Orders
{
    public enum OrderStatusEnum
    {
        AwaitingApproval = 1,
        BeingPrepared = 2,
        InTransit = 3,
        Delivered = 4,

    }
}
