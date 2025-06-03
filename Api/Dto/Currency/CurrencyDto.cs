using System.ComponentModel.DataAnnotations;

namespace Api.Dto.Currences
{
    public class CurrencyDto
    {
        [Required]
        public string? Code { get; set; }
        [Required]
        public decimal Rate { get; set; }
    }
}
