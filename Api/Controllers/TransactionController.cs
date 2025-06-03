using Api.Dto.Transaction;
using Api.Interfaces;
using Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/Transaction")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IWalletRepository _walletRepository;

        public TransactionController(ITransactionRepository transactionRepository, IWalletRepository walletRepository)
        {
            _transactionRepository = transactionRepository;
            _walletRepository = walletRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]string id)
        {
            var Transaction = await _transactionRepository.GetById(id);
            if (Transaction == null)
            {
                return NotFound();
            }
            return Ok(Transaction.ToTransactionDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionDto transactionDto)
        {
            var walletModel = _walletRepository.ChangeBalance(transactionDto);
            if (walletModel == null)
            {
                return NotFound();  
            }
            var transactionModel = transactionDto.ToTransactionModel();
            await _transactionRepository.CreateAsync(transactionModel);
            return CreatedAtAction(nameof(GetById), new { id = transactionModel.TransactionId }, transactionModel.ToTransactionDto());

        }

        [HttpDelete("{deleteId}")]
        public async Task<IActionResult> Delete([FromRoute] string deleteId)
        {
            var transactionModel = await _transactionRepository.DeleteAsync(deleteId);

            if (transactionModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("{UpdateId}")]
        public async Task<IActionResult> Update([FromRoute] string UpdateId, [FromBody] TransactionDto transactionDto)
        {
            var transactionModel = await _transactionRepository.UpdateAsync(UpdateId, transactionDto);
            if (transactionModel == null)
            {
                return NotFound();
            }
            return Ok(transactionModel.ToTransactionDto());
        }
    }
}
