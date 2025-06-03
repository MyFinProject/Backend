using Api.Data;
using Api.Dto.Currences;
using Api.Interfaces;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly ApplicationDbContext _context;
        public CurrencyRepository(ApplicationDbContext dbContext) 
        {
            _context = dbContext;
        }

        public async Task<Currency> CreateAsync(Currency currencieModel)
        {
            await _context.Currencies.AddAsync(currencieModel);
            await _context.SaveChangesAsync();
            return currencieModel;
        }

        public async Task<Currency?> DeleteAsync(string id)
        {
            var CurrencieModel = await _context.Currencies.FirstOrDefaultAsync(x => x.CurrencieId == id);

            if (CurrencieModel == null)
            {
                return null;
            }
            
            _context.Currencies.Remove(CurrencieModel);
            await _context.SaveChangesAsync();
            return CurrencieModel;
        }

        public async Task<List<Currency>> GetAllAsync()
        {
            return await _context.Currencies.ToListAsync();
        }

        public async Task<Currency?> GetByCodeAsync(string Code)
        {
            return await _context.Currencies.FirstOrDefaultAsync(x => x.Code == Code);
        }

        public async Task<Currency> UpdateAsync(string id, CurrencyDto currenceDto)
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
