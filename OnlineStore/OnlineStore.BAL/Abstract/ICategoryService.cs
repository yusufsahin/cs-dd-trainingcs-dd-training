using OnlineStore.Entity.Concrete;

namespace OnlineStore.BAL.Abstract
{
    public interface ICategoryService
    {
        Task<IList<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int categoryId);
        Task<Category> AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int categoryId);
    }
}
