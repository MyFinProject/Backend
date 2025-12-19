using System.ComponentModel.DataAnnotations;

namespace Api.Dto.Wallets
{
    public class NewWalletDto
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public string CurrencieId { get; set; }
        [Required]
        public string ImageAdress { get; set; }
    }
}
