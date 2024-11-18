using Microsoft.EntityFrameworkCore;
using OnlineStore.Entity.Concrete;

namespace OnlineStore.DAL.Concrete
{
    public class OnlineStoreDbContext:DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public OnlineStoreDbContext(DbContextOptions<OnlineStoreDbContext> options):base(options)
        {
            
        }
    }
}
