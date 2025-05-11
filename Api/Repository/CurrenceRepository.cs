using Api.Data;
using Api.Dto.Currences;
using Api.Interfaces;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class CurrenceRepository : ICurrenceRepository
    {
        private readonly ApplicationDbContext _context;
        public CurrenceRepository(ApplicationDbContext dbContext) 
        {
            _context = dbContext;
        }

        public async Task<Currencie> CreateAsync(Currencie currencieModel)
        {
            await _context.Currencies.AddAsync(currencieModel);
            await _context.SaveChangesAsync();
            return currencieModel;
        }

        public async Task<Currencie?> DeleteAsync(string id)
        {
            var CurrencieModel = await _context.Currencies.FirstOrDefaultAsync(x => x.CurrencieId == id);

            if (CurrencieModel != null)
            {
                return null;
            }
            
            _context.Currencies.Remove(CurrencieModel);
            await _context.SaveChangesAsync();
            return CurrencieModel;
        }

        public async Task<List<Currencie>> GetAllAsync()
        {
            return await _context.Currencies.ToListAsync();
        }

        public async Task<Currencie?> GetByIdAsync(string id)
        {
            return await _context.Currencies.FindAsync(id);
        }

        public async Task<Currencie> UpdateAsync(string id, CurrenceDto currenceDto)
        {
            var existingCurrence = await _context.Currencies.FirstOrDefaultAsync(x =>x.CurrencieId == id);

            if (existingCurrence != null)
            {
                return null;
            }

            existingCurrence.Rate = currenceDto.Rate;
            existingCurrence.Code = currenceDto.Code;

            await _context.SaveChangesAsync();

            return existingCurrence;
        }
    }
}
