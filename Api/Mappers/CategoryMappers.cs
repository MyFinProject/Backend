using Api.Dto.Category;
using Api.Models;

namespace Api.Mappers
{
    public static class CategoryMappers
    {
        public static CategoryDto ToCategoryDto(this Category categoryModel)
        {
            return new CategoryDto
            {
                Icon = categoryModel.Icon,
                Name = categoryModel.Name,
            };
        }

        public static Category ToCategoryModel(this CategoryDto categoryDto)
        {
            return new Category
            {
                Icon = categoryDto.Icon,
                Name = categoryDto.Name,
            };
        }
    }
}
