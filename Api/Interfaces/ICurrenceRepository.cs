using Api.Models;

namespace Api.Interfaces
{
    public interface ICurrenceRepository
    {
        public Task<List<Currencie>> GetAllAsync();   
    }
}
