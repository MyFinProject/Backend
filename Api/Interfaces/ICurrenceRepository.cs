using Api.Dto.Currences;
using Api.Models;

namespace Api.Interfaces
{
    public interface ICurrenceRepository
    {
        public Task<List<Currencie>> GetAllAsync();
        public Task<Currencie?> GetByCodeAsync(string Code);
        public Task<Currencie> CreateAsync(Currencie currencieModel);
        public Task<Currencie> UpdateAsync(string id, CurrenceDto currenceDto);
        public Task<Currencie?> DeleteAsync(string id);
    }
}
