using OnlineStore.Core.DataAccess.EntityFramework;
using OnlineStore.DAL.Abstract;
using OnlineStore.Entity.Concrete;
namespace OnlineStore.DAL.Concrete.EntityFrameWork
{
    public class CategoryDal : EfEntityRepositoryBase<Category>, ICategoryDal
    {
        public CategoryDal(OnlineStoreDbContext onlineStoreDbContext) : base(onlineStoreDbContext)
        {
            // Constructor calls the base class, no additional logic needed
        }
    }
}