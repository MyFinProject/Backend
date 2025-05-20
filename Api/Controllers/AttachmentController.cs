using Api.Dto.Attachment;
using Api.Dto.Transaction;
using Api.Interfaces;
using Api.Mappers;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/attachment")]
    public class AttachmentController : ControllerBase
    {
        private readonly IAttachmentService _attachmentService;
        private readonly IAttachmentRepository _attachmentRepository;
        public AttachmentController(IAttachmentService attachmentService, IAttachmentRepository attachmentRepository) 
        {
            _attachmentRepository = attachmentRepository;
            _attachmentService = attachmentService;
        }
        [HttpPost("{WalletId}")]
        public async Task<IActionResult> CreatеTransForAttachment([FromRoute] string WalletId,[FromBody] AttachmentDto attachmentDto)
        {
            CheckModel? check = await _attachmentService.ReadQr(attachmentDto);
            if(check == null)
            {
                return StatusCode(456, check);
            }
            Attachment attachmentModel = await _attachmentRepository.CreateTransAndAtt(attachmentDto, WalletId, check);

            return Ok(attachmentModel);
        }
    }
}
