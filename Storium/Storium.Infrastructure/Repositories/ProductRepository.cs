using Microsoft.EntityFrameworkCore;
using Storium.Domain.Products;
using Storium.Domain.Shared;
using Storium.Infrastructure.Context;

namespace Storium.Infrastructure.Repositories
{
    internal sealed class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(string name, int quantity, decimal amount, string currency, Guid categoryId, CancellationToken cancellationToken = default)
        {
            Product product = new(
                Guid.NewGuid(), 
                new(name), 
                quantity, 
                new(amount, Currency.FromCode(currency)), 
                categoryId);

            await _context.Products.AddAsync(product, cancellationToken);
        }

        public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Products.ToListAsync(cancellationToken);
        }
    }
}
