using Api.Data;
using Api.Interfaces;
using Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext applicationDb) 
        { 
            _context = applicationDb;
        }
        public async Task<Category> CreateAsync(Category categoryModel)
        {
            await _context.AddAsync(categoryModel);
            await _context.SaveChangesAsync();
            return categoryModel;
        }

        public async Task<Category?> DeleteAsync(string id)
        {
            var CategoryModel = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
            if (CategoryModel == null)
            {
                return null;
            }
            _context.Categories.Remove(CategoryModel);
            await _context.SaveChangesAsync();
            return CategoryModel;
        }

        public async Task<Category?> GetByIdAsync(string id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category?> GetByNameAsync(string Name)
        {
            return await _context.Categories.FirstOrDefaultAsync(x => x.Name == Name);
        }

        public async Task<Category?> UpdateAsync(Category categoryModel, string id)
        {
            var CategoryModelEx = await _context.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);

            if (CategoryModelEx == null)
            {
                return null;
            }
            CategoryModelEx.Icon = categoryModel.Icon;
            CategoryModelEx.Name = categoryModel.Name;

            await _context.SaveChangesAsync();

            return CategoryModelEx;
        }
    }
}
