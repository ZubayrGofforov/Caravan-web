using Caravan.Service.Dtos.Accounts;
using Caravan.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Caravan.Api.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register"), AllowAnonymous]
        public async Task<IActionResult> RegisterAsync([FromForm] AccountRegisterDto registerDto)
            => Ok(await _accountService.RegisterAsync(registerDto));

        
        [HttpPost("login"), AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromForm] AccountLoginDto loginDto)
            => Ok(new {Token = await _accountService.LoginAsync(loginDto)});
        
        
        [HttpPost("reset-password"), Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> ForgetPasswordAsync([FromForm]UserResetPasswordDto userResetPassword)
            => Ok(await _accountService.VerifyPasswordAsync(userResetPassword));

        
        [HttpPost("sendcode"), AllowAnonymous]
        public async Task<IActionResult> SendToEmailAsync([FromForm] SendToEmailDto sendToEmail)
        {
            await _accountService.SendCodeAsync(sendToEmail);
            return Ok();
        }
        
        
        [HttpPatch("updatePassword"), Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> UpdatePasswordAsync([FromForm] PasswordUpdateDto updatePasswordDto)
            => Ok(await _accountService.PasswordUpdateAsync(updatePasswordDto));
    }
}
