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
        public string CategoryId { get; set; } = "f3f91de411a94471a73ac1c2f0923b3c";
        [Required]
        public double Amount { get; set; }
        [Required]
        public string CurrencieId { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
