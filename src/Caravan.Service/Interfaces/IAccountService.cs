using Caravan.Service.Dtos.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Service.Interfaces
{
    public interface IAccountService
    {
        public Task<bool> PasswordUpdateAsync(PasswordUpdateDto passwordUpdateDto);
        public Task<bool> RegisterAsync(AccountRegisterDto registerDto);
        public Task<string> LoginAsync(AccountLoginDto loginDto);
        public Task SendCodeAsync(SendToEmailDto sendToEmail);
        public Task<bool> VerifyPasswordAsync(UserResetPasswordDto userResetPassword);
    }
}
