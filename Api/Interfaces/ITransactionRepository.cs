using Api.Dto.Currences;
using Api.Dto.Transaction;
using Api.Models;

namespace Api.Interfaces
{
    public interface ITransactionRepository
    {
        public Task<Transaction?> GetById(string id);
        public Task<Transaction> CreateAsync(Transaction transactionModel);
        public Task<Transaction?> UpdateAsync(string id, TransactionDto transactionDto);
        public Task<Transaction?> DeleteAsync(string id);
    }
}
