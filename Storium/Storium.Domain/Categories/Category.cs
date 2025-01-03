﻿using Storium.Domain.Abstractions;
using Storium.Domain.Products;
using Storium.Domain.Shared;

namespace Storium.Domain.Categories
{
    public sealed class Category:Entity
    {
        private Category(Guid id) : base(id)
        {
        }

        public Category(Guid id, Name name) : base(id)
        {
            Name = name;
        }
        public Name Name { get;private set; }

        public ICollection<Product> Products { get; private set; }

        public void ChangeName(string name)
        {
            Name = new(name);
        }
    }
}
