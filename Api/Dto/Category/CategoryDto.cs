using System.ComponentModel.DataAnnotations;

namespace Api.Dto.Category
{
    public class CategoryDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Icon { get; set; }
    }
}
