using Api.Data;
using Api.Dto.Currences;
using Api.Interfaces;
using Api.Mappers;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/Currencie")]
    public class CurrencieController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        private readonly ICurrenceRepository _currenceRepository;
        public CurrencieController(ApplicationDbContext context, ICurrenceRepository currenceRepository)
        {
            _context = context;
            _currenceRepository = currenceRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var Currencies = await _currenceRepository.GetAllAsync();

            var CurreciesDto = Currencies.Select(s => s.ToCurrenceDTO()).ToList();

            return Ok(Currencies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var currencie = await _currenceRepository.GetByIdAsync(id);

            if (currencie == null)
            {
                return NotFound();
            }
            return Ok(currencie.ToCurrenceDTO());
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CurrenceDto currencieDto)
        {
            var CurrencieModel = currencieDto.ToCurrenceFromDto();
            await _currenceRepository.CreateAsync(CurrencieModel);
            return CreatedAtAction(nameof(GetById), new { id = CurrencieModel.CurrencieId }, CurrencieModel.ToCurrenceDTO());

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute]string id,[FromBody] CurrenceDto updateCurrenceDto)
        {
            var currenceModel = await _currenceRepository.UpdateAsync(id, updateCurrenceDto);

            return Ok(currenceModel.ToCurrenceDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var CurrenceModel = await _currenceRepository.DeleteAsync(id);

            if(CurrenceModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
