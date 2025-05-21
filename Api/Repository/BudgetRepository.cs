using Api.Data;
using Api.Dto.Budget;
using Api.Interfaces;
using Api.Mappers;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly ApplicationDbContext _context;

        public BudgetRepository(ApplicationDbContext applicationDb)
        {
            _context = applicationDb;
        }
        public async Task<Budget> CreateAsync(BudgetDto budgetDto)
        {
            Budget budgetModel = budgetDto.ToBudget();
            await _context.AddAsync(budgetModel);
            await _context.SaveChangesAsync();
            return budgetModel;
        }

        public async Task<Budget?> DeleteAsync(string id)
        {
            Budget? budgetModel = await _context.Budgets.FirstOrDefaultAsync(x => x.BudgetId == id);
            if (budgetModel == null)
            {
                return null;
            }
            _context.Budgets.Remove(budgetModel);
            await _context.SaveChangesAsync();
            return budgetModel;
        }

        public async Task<List<Budget>> GetAllByUserIdAsync(string UserId)
        {
            return await _context.Budgets.Where(x => x.UserId == UserId).ToListAsync();
        }

        public async Task<Budget?> GetByIdAsync(string id)
        {
            Budget? budgetModel =  await _context.Budgets.FirstOrDefaultAsync(x => x.BudgetId == id);
            if (budgetModel == null)
            {
                return null;
            }
            return budgetModel;
        }

        public async Task<Budget?> UpdateAsync(BudgetDto budgetDto, string id)
        {
            Budget? budgetModel = await _context.Budgets.FirstOrDefaultAsync(x  => x.BudgetId==id);
            if (budgetModel == null)
            {
                return null;
            }
            budgetModel.CurrencyId =budgetDto.CurrencyId;
            budgetModel.UserId = budgetDto.UserId;
            budgetModel.CategoryId = budgetDto.CategoryId;
            budgetModel.Amount = budgetDto.Amount;
            budgetModel.Name = budgetDto.Name;
            budgetModel.StartDate = budgetDto.StartDate;
            budgetModel.EndDate = budgetDto.EndDate;
            await _context.SaveChangesAsync();
            return budgetModel;
        }
    }
}
