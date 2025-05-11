using Api.Dto.Wallets;
using Api.Models;

namespace Api.Mappers
{
    public static class WalletMappers
    {
        public static UserWallets WalletModelFromDto(this NewWalletDto newWalletDto, string UserId)
        {
            return new UserWallets
            {
                UserId = UserId,
                Name = newWalletDto.Name,
                Balance = 0,
                CurrencieId = newWalletDto.CurrencieId,
            };

        }
        public static WalletDto ToWalletDto(this UserWallets userWallet)
        {
            return new WalletDto
            {
                UserId = userWallet.UserId,
                Name = userWallet.Name,
                Balance = userWallet.Balance,
                CurrencieId = userWallet.CurrencieId,
                IsActive = userWallet.IsActive,
            };
        }
    }
}
