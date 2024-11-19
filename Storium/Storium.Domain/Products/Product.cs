using Storium.Domain.Categories;

namespace Storium.Domain.Products
{
    public sealed class Product
    {
        public Guid Id { get; set; }
        public string  Name { get; set; } 
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
