using Api.Dto.Currences;
using Api.Models;

namespace Api.Interfaces
{
    public interface ICurrencyRepository
    {
        public Task<List<Currency>> GetAllAsync();
        public Task<Currency?> GetByCodeAsync(string Code);
        public Task<Currency> CreateAsync(Currency currencieModel);
        public Task<Currency> UpdateAsync(string id, CurrencyDto currenceDto);
        public Task<Currency?> DeleteAsync(string id);
    }
}
