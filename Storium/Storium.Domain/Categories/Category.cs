using Storium.Domain.Abstractions;
using Storium.Domain.Products;

namespace Storium.Domain.Categories
{
    public sealed class Category:Entity
    {
        public Category(Guid id) : base(id)
        {
        }

        public Category(Guid id, string name) : base(id)
        {
            Name = name;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; private set; }

        public void ChangeName(string name)
        {
            Name = name;
        }
    }
}
