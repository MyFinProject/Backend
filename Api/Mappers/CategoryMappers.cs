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
                Id = categoryModel.CategoryId,
                Icon = categoryModel.Icon,
                Name = categoryModel.Name,
            };
        }

        public static Category ToCategoryModel(this CategoryDto categoryDto)
        {
            return new Category
            {
                CategoryId = categoryDto.Id,
                Icon = categoryDto.Icon,
                Name = categoryDto.Name,
            };
        }
    }
}
