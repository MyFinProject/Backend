using System.ComponentModel.DataAnnotations;

namespace Api.Dto.Attachment
{
    public class AttachmentDto
    {
        [Required]
        public string FilePath { get; set; }
    }
}
