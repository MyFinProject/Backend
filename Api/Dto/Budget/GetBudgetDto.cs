namespace Api.Dto.Budget
{
    public class GetBudgetDto
    {
        public string BudgetId { get; set; }
        public string UserId { get; set; }
        public string CategoryId { get; set; }
        public int Amount { get; set; }
        public string CurrencyId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
