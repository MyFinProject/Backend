using Api.Dto.Wallets;
using Api.Models;

namespace Api.Interfaces
{
    public interface IWalletRepository
    {
        Task<UserWallets?> GetByIdAsync (string id);
        Task<UserWallets?> GetIdByName(string Name);
        Task<UserWallets> CreateAsync(UserWallets walletsModel);
        Task<List<UserWallets>> GetAllByUserIdAsync (string userId);
        Task<UserWallets?> DeleteAsync (string id);
        Task<UserWallets> UpdateAsync(string id, WalletDto walletDto);
    }
}
