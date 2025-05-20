using Api.Dto.Wallets;
using Api.Interfaces;
using Api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/wallets")]
    public class WalletController : ControllerBase
    {
        private readonly IWalletRepository _WalletRepo;
        public WalletController(IWalletRepository walletRepository)
        {
            _WalletRepo = walletRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var wallets = await _WalletRepo.GetByIdAsync(id);

            if (wallets == null)
            {
                return NotFound();
            }
            return Ok(wallets.ToWalletDto());
        }

        [HttpGet("AllByUserId{UserId}")]
        public async Task<IActionResult> GetAllByUserId([FromRoute] string UserId)
        {
            var Wallets = await _WalletRepo.GetAllByUserIdAsync(UserId);
            if (Wallets == null)
            {
                return NotFound();
            }
            var WalletsDto = Wallets.Select(w => w.ToWalletDto()).ToList();
            return Ok(WalletsDto);
        }

        [HttpGet("IdByName{Name}")]
        public async Task<IActionResult> IdByName([FromRoute] string Name)
        {
            var WalletModel = await _WalletRepo.GetIdByName(Name);
            if(WalletModel == null)
            {
                return NotFound();
            }
            return Ok(WalletModel.WalletId);
        }

        [HttpDelete("DeleteWallet{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var WalletModel = await _WalletRepo.DeleteAsync(id);
            if (WalletModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{IdForUpdate}")]
        public async Task<IActionResult> Update([FromRoute] string IdForUpdate, [FromBody] WalletDto walletDto)
        {
            var WalletModel = await _WalletRepo.UpdateAsync(IdForUpdate, walletDto);
            return Ok(WalletModel);
        }

        [HttpPost("{UserId}")]
        public async Task<IActionResult> Create([FromRoute] string UserId, [FromBody]NewWalletDto walletDto)
        {
            var walletModel = walletDto.WalletModelFromDto(UserId);
            await _WalletRepo.CreateAsync(walletModel);
            return CreatedAtAction(nameof(GetById), new { id = walletModel }, walletModel.ToWalletDto());
        }
    }
}
