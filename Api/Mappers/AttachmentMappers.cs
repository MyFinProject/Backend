using Api.Dto.Attachment;
using Api.Models;

namespace Api.Mappers
{
    public static class AttachmentMappers
    {
        public static Attachment ToAttachmentModel(this AttachmentDto attachmentDto)
        {
            return new Attachment
            {
                FilePath = attachmentDto.FilePath,
            };
        }

        public static AttachmentDto ToAttachmentDto(this Attachment attachment)
        {
            return new AttachmentDto
            {
                FilePath = attachment.FilePath,
            };
        }
    }
}
