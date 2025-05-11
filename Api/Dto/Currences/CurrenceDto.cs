using System.ComponentModel.DataAnnotations;

namespace Api.Dto.Currences
{
    public class CurrenceDto
    {
        [Required]
        public string? Code { get; set; }
        [Required]
        public decimal Rate { get; set; }
    }
}
