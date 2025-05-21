using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Api.Models
{
    public class Budget
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string BudgetId { get; set; } = Guid.NewGuid().ToString("N");
        public string UserId { get; set; } = string.Empty;
        public string CategoryId { get; set; } = string.Empty;
        public int Amount { get; set; }
        public string CurrencyId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime EndDate { get; set; }
        public AppUser? AppUser { get; set; }
        public Category? Category { get; set; }
        public Currencie? Currencie { get; set; }
    }
}