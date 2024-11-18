using OnlineStore.BAL.Abstract;
using OnlineStore.DAL.Abstract;
using OnlineStore.Entity.Concrete;

namespace OnlineStore.BAL.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task<Category> AddAsync(Category category)
        {
            await _categoryDal.AddAsync(category,true); // Correct AddAsync implementation
            return category;
        }


        public async Task DeleteAsync(int categoryId)
        {
            await _categoryDal.DeleteAsync(categoryId,true);
        }

        public async  Task<IList<Category>> GetAllAsync()
        {
            return await _categoryDal.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int categoryId)
        {
            return await _categoryDal.GetByIdAsync(categoryId);
        }

        public async Task UpdateAsync(Category category)
        {
             await _categoryDal.UpdateAsync(category,true);
        }
    }
}
