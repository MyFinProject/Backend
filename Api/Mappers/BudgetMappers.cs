using Api.Dto.Budget;
using Api.Models;

namespace Api.Mappers
{
    public static class BudgetMappers
    {
        public static Budget ToBudget(this BudgetDto budgetDto)
        {
            return new Budget
            {
                Name = budgetDto.Name,
                UserId = budgetDto.UserId,
                CategoryId = budgetDto.CategoryId,
                Amount = budgetDto.Amount,
                CurrencyId = budgetDto.CurrencyId,
                StartDate = budgetDto.StartDate,
                EndDate = budgetDto.EndDate,
            };
        }
        public static BudgetDto ToBudgetDto(this Budget budgetModel)
        {
            return new BudgetDto
            {
                Name = budgetModel.Name,
                UserId = budgetModel.UserId,
                CategoryId = budgetModel.CategoryId,
                Amount = budgetModel.Amount,
                CurrencyId = budgetModel.CurrencyId,
                StartDate = budgetModel.StartDate,
                EndDate = budgetModel.EndDate,
            };
        }
        public static GetBudgetDto ToGetBudgetDto(this Budget budgetModel)
        {
            return new GetBudgetDto
            {
                BudgetId = budgetModel.BudgetId,
                Name = budgetModel.Name,
                UserId = budgetModel.UserId,
                CategoryId = budgetModel.CategoryId,
                Amount = budgetModel.Amount,
                CurrencyId = budgetModel.CurrencyId,
                StartDate = budgetModel.StartDate,
                EndDate = budgetModel.EndDate,
            };
        }

    }

}
