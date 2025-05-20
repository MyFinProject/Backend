using System.ComponentModel.DataAnnotations;

namespace Api.Dto.Transaction
{
    public class TransactionDto
    {
        [Required]
        public string WalletId { get; set; } = string.Empty;
        [Required]
        public int TypeOperation { get; set; }
        [Required]
        public string CategoryId { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public string CurrencieId { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
