using Api.Dto.Budget;
using Api.Models;

namespace Api.Interfaces
{
    public interface IBudgetRepository
    {
        public Task<Budget> CreateAsync(BudgetDto budgetDto);
        public Task<Budget?> UpdateAsync(BudgetDto budgetDto, string id);
        public Task<Budget?> DeleteAsync(string id);
        public Task<Budget?> GetByIdAsync(string id);
        public Task<List<Budget>> GetAllByUserIdAsync(string UserId);
    }
}
