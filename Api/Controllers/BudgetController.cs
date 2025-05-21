using Api.Dto.Budget;
using Api.Interfaces;
using Api.Mappers;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetRepository _budgetRepository;

        public BudgetController(IBudgetRepository budgetRepository)
        {
            _budgetRepository = budgetRepository;
        }

        [HttpGet("GetById/{BudgetId}")]
        public async Task<IActionResult> GetById([FromRoute] string BudgetId)
        {
            Budget? budgetModel = await _budgetRepository.GetByIdAsync(BudgetId);
            if (budgetModel == null)
            {
                return NotFound();
            }
            return Ok(budgetModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BudgetDto budgetDto)
        {
            Budget budgetModel = await _budgetRepository.CreateAsync(budgetDto);
            return CreatedAtAction(nameof(GetById), new { id = budgetModel.BudgetId }, budgetModel.ToBudgetDto());
        }

        [HttpGet("GetAllByUserId/{UserId}")]
        public async Task<IActionResult> GetAllByUserId([FromRoute] string UserId)
        {
            var budgets = await _budgetRepository.GetAllByUserIdAsync(UserId);
            if (budgets == null)
            {
                return NotFound();
            }
            var budgetsDto = budgets.Select(s => s.ToGetBudgetDto()).ToList();
            return Ok(budgetsDto);
        }
        [HttpDelete("Delete/{DeleteId}")]
        public async Task<IActionResult> Delete([FromRoute] string DeleteId)
        {
            Budget? budgetModel = await _budgetRepository.DeleteAsync(DeleteId);
            if (budgetModel == null)
            {
                return NotFound();
            }
            return Ok(budgetModel);
        }
        [HttpPut("Update/{UpdateId}")]
        public async Task<IActionResult> Update([FromRoute] string UpdateId, [FromBody] BudgetDto budgetDto)
        {
            Budget? budgetModel = await _budgetRepository.UpdateAsync(budgetDto, UpdateId); 
            if (budgetModel == null)
            {
                return NotFound();
            }
            return Ok(budgetModel);
        }
    }
}
