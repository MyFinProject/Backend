using Api.Data;
using Api.Dto.Wallets;
using Api.Interfaces;
using Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class WalletRepository : IWalletRepository
    {
        private readonly ApplicationDbContext _context;
        public WalletRepository(ApplicationDbContext dbContext) 
        { 
            _context = dbContext;
        }
        public async Task<UserWallets> CreateAsync(UserWallets walletsModel)
        {
            await _context.AddAsync(walletsModel);
            await _context.SaveChangesAsync();
            return walletsModel;
        }

        public async Task<UserWallets?> DeleteAsync(string id)
        {
            var WalletModel = await _context.UserWallets.FirstOrDefaultAsync(w => w.WalletId == id);
            if (WalletModel == null)
            {
                return null;
            }
            _context.UserWallets.Remove(WalletModel);
            await _context.SaveChangesAsync();
            return WalletModel;

        }

        public async Task<List<UserWallets>> GetAllByUserIdAsync(string userId)
        {
            return await _context.UserWallets.Where(w => w.UserId == userId).ToListAsync();
        }

        public async Task<UserWallets?> GetByIdAsync(string id)
        {
            return await _context.UserWallets.FindAsync(id);
        }

        public async Task<UserWallets?> GetIdByName(string Name)
        {
            var WalletModel = await _context.UserWallets.FirstOrDefaultAsync(x => x.Name == Name);
            return WalletModel;
        }

        public async Task<UserWallets> UpdateAsync(string id, WalletDto updateWalletDto)
        {
            var existingWallet = await _context.UserWallets.FirstOrDefaultAsync(w => w.WalletId == id);
            if (existingWallet == null)
            {
                return null;
            }
            existingWallet.UserId = updateWalletDto.UserId;
            existingWallet.CurrencieId = updateWalletDto.CurrencieId;
            existingWallet.Balance= updateWalletDto.Balance;
            existingWallet.IsActive = updateWalletDto.IsActive;
            existingWallet.Name = updateWalletDto.Name;
            return existingWallet;
        }
    }
}
