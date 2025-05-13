using Api.Data;
using Api.Dto.Transaction;
using Api.Interfaces;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;
        public TransactionRepository(ApplicationDbContext dbContext) 
        {
            _context = dbContext;
        }
        public async Task<Transaction> CreateAsync(Transaction transactionModel)
        {
            await _context.Transactions.AddAsync(transactionModel);
            await _context.SaveChangesAsync();
            return transactionModel;
        }

        public async Task<Transaction?> DeleteAsync(string id)
        {
            var transactionModel = await _context.Transactions.FirstOrDefaultAsync(x => x.TransactionId == id);

            if (transactionModel == null)
            {
                return null;
            }
            _context.Transactions.Remove(transactionModel);
            await _context.SaveChangesAsync();
            return transactionModel;

        }

        public async Task<Transaction?> GetById(string id)
        {
            var transactionModel = await _context.Transactions.FindAsync(id);

            if (transactionModel == null)
            {
                return null;
            }
            return transactionModel;
        }

        public async Task<Transaction?> UpdateAsync(string id, TransactionDto transactionDto)
        {
            var transactionModel = await _context.Transactions.FirstOrDefaultAsync(x => x.TransactionId == id);

            if(transactionModel == null)
            {
                return null;
            }
            transactionModel.CurrencieId = transactionDto.CurrencieId;
            transactionModel.UserId = transactionDto.UserId;
            transactionModel.WalletId = transactionDto.WalletId;
            transactionModel.CategoryId = transactionDto.CategoryId;
            transactionModel.Amount = transactionDto.Amount;
            transactionModel.Description = transactionDto.Description;

            await _context.SaveChangesAsync();

            return transactionModel;

        }
    }
}
