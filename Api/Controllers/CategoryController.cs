using Api.Dto.Category;
using Api.Interfaces;
using Api.Mappers;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var CategoryModel = await _categoryRepository.GetByIdAsync(id);
            if (CategoryModel == null)
            {
                return NotFound();
            }
            return Ok(CategoryModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryDto categoryDto)
        {
            var categoryModel = categoryDto.ToCategoryModel();

            await _categoryRepository.CreateAsync(categoryModel);

            return CreatedAtAction(nameof(GetById), new { id = categoryModel.CategoryId }, categoryModel.ToCategoryDto());
        }

        [HttpDelete("{DeleteId}")]
        public async Task<IActionResult> Delete([FromRoute] string DeleteId)
        {
            var ControllerModel = await _categoryRepository.DeleteAsync(DeleteId);

            if (ControllerModel == null)
            {
                return NotFound();
            }
            return Ok(ControllerModel);
        }

        [HttpPut("{UpdateId}")]
        public async Task<IActionResult> Update([FromRoute] string UpdateId, [FromBody] CategoryDto categoryDto)
        {
            var categoryModel = categoryDto.ToCategoryModel();

            categoryModel = await _categoryRepository.UpdateAsync(categoryModel, UpdateId);
            if(categoryModel == null)
            {
                return NotFound();
            }
            return Ok(categoryModel);
        }
    }
}
