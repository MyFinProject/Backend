using Api.Models;

namespace Api.Interfaces
{
    public interface IWalletRepository
    {
        Task<UserWallets?> GetByIdAsync (string id);
        Task<UserWallets> CreateAsync(UserWallets walletsModel);
    }
}
