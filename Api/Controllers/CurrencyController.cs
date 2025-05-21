using Api.Data;
using Api.Dto.Currences;
using Api.Interfaces;
using Api.Mappers;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/Currency")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyRepository _currenceRepository;
        public CurrencyController(ApplicationDbContext context, ICurrencyRepository currenceRepository)
        {
            _currenceRepository = currenceRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var Currencies = await _currenceRepository.GetAllAsync();

            var CurreciesDto = Currencies.Select(s => s.ToCurrenceDTO()).ToList();

            return Ok(Currencies);
        }

        [HttpGet("{Code}")]
        public async Task<IActionResult> GetByCode([FromRoute] string Code)
        {
            var currencie = await _currenceRepository.GetByCodeAsync(Code);

            if (currencie == null)
            {
                return NotFound();
            }
            return Ok(currencie.ToCurrenceDTO());
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CurrencyDto currencieDto)
        {
            var CurrencieModel = currencieDto.ToCurrenceFromDto();
            await _currenceRepository.CreateAsync(CurrencieModel);
            return CreatedAtAction(nameof(GetByCode), new { id = CurrencieModel.CurrencieId }, CurrencieModel.ToCurrenceDTO());

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute]string id,[FromBody] CurrencyDto updateCurrenceDto)
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
