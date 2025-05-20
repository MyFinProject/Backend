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
                TypeOperation = transactionModel.TypeOperation,
                CategoryId = transactionModel.CategoryId,
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
                TypeOperation = transactionDto.TypeOperation,
                CategoryId = transactionDto.CategoryId,
                WalletId = transactionDto.WalletId,
                CurrencieId = transactionDto.CurrencieId,
                Description = transactionDto.Description,
            };
        }
    }
}
