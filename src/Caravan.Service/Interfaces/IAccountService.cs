using Caravan.Service.Dtos.Accounts;
using Caravan.Service.Dtos.Admins;

namespace Caravan.Service.Interfaces
{
    public interface IAccountService
    {
        public Task<bool> AdminRegisterAsync(AdminCreateDto dto);
        public Task<bool> PasswordUpdateAsync(PasswordUpdateDto passwordUpdateDto);
        public Task<bool> RegisterAsync(AccountRegisterDto registerDto);
        public Task<string> LoginAsync(AccountLoginDto loginDto);
        public Task SendCodeAsync(SendToEmailDto sendToEmail);
        public Task<bool> VerifyPasswordAsync(UserResetPasswordDto userResetPassword);
    }
}
