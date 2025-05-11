using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Attachment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string AttachmentId { get; set; } = Guid.NewGuid().ToString("N");
        public string TransactionId { get; set; } = string.Empty;
        public string FilePath { get; set; } = String.Empty;
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

        public Transaction? Transaction { get; set; }

    }
}
    