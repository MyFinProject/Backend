using Api.Data;
using Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;
        public AccountRepository(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<bool> CheckEmail(string Email)
        {
            var Acc = await _context.Users.FirstOrDefaultAsync(x => x.Email == Email);
            if (Acc == null)
            {
                return true;
            }
            return false;
        }
    }
}
