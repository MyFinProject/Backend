using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Api.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CategoryId { get; set; } = Guid.NewGuid().ToString("N");
        public string Name { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public List<Budget> Budgets { get; set; } = new List<Budget>();
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}