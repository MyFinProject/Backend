using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string TransactionId { get; set; } = Guid.NewGuid().ToString("N");
        public String UserId { get; set; } = string.Empty;
        public string CategoryId { get; set; } = string.Empty;
        public int Amount { get; set; }
        public string WalletId { get; set; } = string.Empty;
        public string CurrencieId { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Description { get; set; } = string.Empty;
        public UserWallets? UserWallets { get; set; }
        public AppUser? AppUser { get; set; }
        public Category? Category { get; set; }
        public Currencie? Currencie { get; set; }
        public List<Attachment> Attachments { get; set; } = new List<Attachment>();

    }
}
