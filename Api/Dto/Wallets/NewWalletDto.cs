using System.ComponentModel.DataAnnotations;

namespace Api.Dto.Wallets
{
    public class NewWalletDto
    {
        [Required]
        public String UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Balance { get; set; }
        [Required]
        public string CurrencieId { get; set; }
    }
}
