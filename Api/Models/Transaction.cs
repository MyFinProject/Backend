using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string TransactionId { get; set; } = Guid.NewGuid().ToString("N");
        public int TypeOperation { get; set; }
        public string CategoryId { get; set; } = string.Empty;
        public double Amount { get; set; }
        public string WalletId { get; set; } = string.Empty;
        public string CurrencieId { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Description { get; set; } = string.Empty;
        public UserWallets? UserWallets { get; set; }
        public Category? Category { get; set; }
        public Currencie? Currencie { get; set; }
        public List<Attachment> Attachments { get; set; } = new List<Attachment>();

    }
}
