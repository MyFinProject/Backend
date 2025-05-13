using Api.Dto.Transaction;
using Api.Models;

namespace Api.Mappers
{
    public static class TransactionMappers
    {
        public static TransactionDto ToTransactionDto(this Transaction transactionModel)
        {
            return new TransactionDto
            {
                Amount = transactionModel.Amount,
                CategoryId = transactionModel.CategoryId,
                UserId = transactionModel.UserId,
                WalletId = transactionModel.WalletId,
                CurrencieId = transactionModel.CurrencieId,
                Description = transactionModel.Description,
            };
        }

        public static Transaction ToTransactionModel(this TransactionDto transactionDto)
        {
            return new Transaction
            {
                Amount = transactionDto.Amount,
                CategoryId = transactionDto.CategoryId,
                UserId = transactionDto.UserId,
                WalletId = transactionDto.WalletId,
                CurrencieId = transactionDto.CurrencieId,
                Description = transactionDto.Description,
            };
        }
    }
}
