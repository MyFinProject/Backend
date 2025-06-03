using Api.Dto.Transaction;
using Api.Dto.Wallets;
using Api.Models;

namespace Api.Interfaces
{
    public interface IWalletRepository
    {
        public Task<UserWallets?> GetByIdAsync (string id);
        public Task<UserWallets?> ChangeBalance(TransactionDto transactionDto);
        public Task<UserWallets?> GetIdByName(string Name);
        public Task<UserWallets> CreateAsync(UserWallets walletsModel);
        public Task<List<UserWallets>> GetAllByUserIdAsync (string userId);
        public Task<UserWallets?> DeleteAsync (string id);
        public Task<UserWallets> UpdateAsync(string id, WalletDto walletDto);
    }
}
