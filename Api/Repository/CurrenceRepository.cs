using Api.Data;
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
        public Task<List<Currencie>> GetAllAsync()
        {
            return _context.Currencies.ToListAsync();
        }
    }
}
