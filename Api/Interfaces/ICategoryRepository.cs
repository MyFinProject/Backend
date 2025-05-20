using Api.Models;

namespace Api.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<Category> CreateAsync(Category categoryModel);
        public Task<Category?> UpdateAsync(Category categoryModel, string id);
        public Task<Category?> GetByNameAsync(string Name);
        public Task<Category?> DeleteAsync(string id);
        public Task<Category?> GetByIdAsync(string id);
    }
}
