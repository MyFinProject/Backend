using Api.Data;
using Api.Dto.Currences;
using Api.Interfaces;
using Api.Mappers;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
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

            var CurreciesDto = Currencies.Select(s => s.ToCurrenceDTO);

            return Ok(Currencies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var currencie = await _context.Currencies.FindAsync(id);

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
            await _context.Currencies.FindAsync(CurrencieModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = CurrencieModel.CurrencieId }, CurrencieModel.ToCurrenceDTO());

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute]string id,[FromBody] CurrenceDto updateCurrenceDto)
        {
            var currenceModel = await _context.Currencies.FindAsync(id);

            if (currenceModel == null)
            {
                return NotFound();
            }

            currenceModel.Rate = updateCurrenceDto.Rate;
            currenceModel.Code = updateCurrenceDto.Code;

            await _context.SaveChangesAsync();

            return Ok(currenceModel.ToCurrenceDTO());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var currenceModel = await _context.Currencies.FirstOrDefaultAsync(x => x.CurrencieId == id);

            if (currenceModel == null)
            {
                return NotFound();
            }

            _context.Currencies.Remove(currenceModel);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
