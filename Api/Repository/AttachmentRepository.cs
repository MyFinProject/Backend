using Api.Data;
using Api.Dto.Attachment;
using Api.Dto.Transaction;
using Api.Interfaces;
using Api.Mappers;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository
{
    public class AttachmentRepository : IAttachmentRepository
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICurrencyRepository _currenceRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ApplicationDbContext _context;
        public AttachmentRepository(ITransactionRepository transactionRepository, ICurrencyRepository currenceRepository, 
            ApplicationDbContext applicationDbContext, ICategoryRepository category) 
        {
            _categoryRepository = category;
            _context = applicationDbContext;
            _currenceRepository = currenceRepository;
            _transactionRepository = transactionRepository;
        }
        public async Task<Attachment> CreateAsync(AttachmentDto attachmentDto)
        {
            Attachment attachmentModel = attachmentDto.ToAttachmentModel();
            await _context.Attachments.AddAsync(attachmentModel);
            await _context.SaveChangesAsync();

            return attachmentModel;
        }

        public async Task<Attachment> CreateTransAndAtt(AttachmentDto attachmentDto, string WalletId, CheckModel check)
        {
            Currency? CurrencieModel = await _currenceRepository.GetByCodeAsync("RUB");
            Category? categoryModel = await _categoryRepository.GetByNameAsync("Product");
            TransactionDto transaction = new TransactionDto
            {
                WalletId = WalletId,
                CategoryId = categoryModel.CategoryId,
                Description = "",
                Amount = check.totalSum,
                CurrencieId = CurrencieModel.CurrencieId
            };
            Transaction transactionModel = transaction.ToTransactionModel();
            transactionModel = await _transactionRepository.CreateAsync(transactionModel);
            Attachment attachmentModel = new Attachment
            {
                FilePath = attachmentDto.FilePath,
                TransactionId = transactionModel.TransactionId,
            };
            await _context.AddAsync(attachmentModel);
            await _context.SaveChangesAsync();

            return attachmentModel;
        }

        public async Task<Attachment> Delete(string AttachmentId)
        {
            var attachmentModel = await _context.Attachments.FirstOrDefaultAsync(x => x.AttachmentId == AttachmentId);
            if (attachmentModel == null)
            {
                return null;
            }
            _context.Attachments.Remove(attachmentModel);
            await _context.SaveChangesAsync();
            return attachmentModel;
        }
    }
}
