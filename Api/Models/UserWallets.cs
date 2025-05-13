using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Api.Models
{
    public class UserWallets
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string WalletId { get; set; } = Guid.NewGuid().ToString("N");
        public String UserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Balance { get; set; }
        public string CurrencieId { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public AppUser? AppUser { get; set; }
        public Currencie? Currencie { get; set; }
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}