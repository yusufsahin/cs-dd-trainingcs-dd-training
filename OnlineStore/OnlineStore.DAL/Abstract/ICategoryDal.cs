using OnlineStore.Core.DataAccess;
using OnlineStore.Entity.Concrete;

namespace OnlineStore.DAL.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        // Custom methods for Category-specific operations can be added here
    }
}
