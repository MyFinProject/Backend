using Api.Dto.Attachment;
using Api.Models;

namespace Api.Interfaces
{
    public interface IAttachmentService
    {
       public Task<CheckModel?> ReadQr(AttachmentDto attachmentDto);
     //  string CreateWallet(Check check);
    }
}
