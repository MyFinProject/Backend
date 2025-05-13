using System.ComponentModel.DataAnnotations;

namespace Api.Dto.Transaction
{
    public class TransactionDto
    {
        [Required]
        public String UserId { get; set; }
        [Required]
        public string WalletId { get; set; } = string.Empty;
        [Required]
        public string CategoryId { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public string CurrencieId { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
