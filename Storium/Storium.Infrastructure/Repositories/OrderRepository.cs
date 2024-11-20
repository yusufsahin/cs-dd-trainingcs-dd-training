using Microsoft.EntityFrameworkCore;
using Storium.Domain.Orders;
using Storium.Infrastructure.Context;

namespace Storium.Infrastructure.Repositories
{
    internal sealed class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Order> CreateAsync(List<CreateOrderDto> createOrderDtos, CancellationToken cancellationToken = default)
        {
            Order order = new(
                Guid.NewGuid(),
                "1",
                DateTime.Now,
                OrderStatusEnum.AwaitingApproval
                );

            order.CreateOrder(createOrderDtos);

            await _context.Orders.AddAsync(order, cancellationToken);
            return order;
        }

        public async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Orders
                .Include(x => x.OrderLines)
                .ThenInclude(x => x.Product)
                .ToListAsync(cancellationToken);
        }
    }
}
