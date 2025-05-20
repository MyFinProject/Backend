using Api.Dto.Attachment;
using Api.Models;

namespace Api.Interfaces
{
    public interface IAttachmentRepository
    {
        public Task<Attachment> CreateAsync(AttachmentDto attachmentDto);
        public Task<Attachment> CreateTransAndAtt(AttachmentDto attachmentDto, string WalletId, CheckModel check);
        public Task<Attachment> Delete(string AttachmentId);
    }
}
