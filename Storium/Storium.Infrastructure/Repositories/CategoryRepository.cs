﻿using Microsoft.EntityFrameworkCore;
using Storium.Domain.Categories;
using Storium.Infrastructure.Context;


namespace Storium.Infrastructure.Repositories
{
    internal sealed class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(string name, CancellationToken cancellationToken = default)
        {
            Category category = new(Guid.NewGuid(), new(name));
            await _context.Categories.AddAsync(category, cancellationToken);
        }

        public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default)
        {
           return await _context.Categories.ToListAsync(cancellationToken);
        }
    }
}
