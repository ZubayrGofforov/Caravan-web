using AutoMapper;
using Caravan.DataAccess.Interfaces.Common;
using Caravan.Domain.Entities;
using Caravan.Service.Common.Exceptions;
using Caravan.Service.Common.Helpers;
using Caravan.Service.Common.Security;
using Caravan.Service.Dtos.Accounts;
using Caravan.Service.Dtos.Admins;
using Caravan.Service.Dtos.Common;
using Caravan.Service.Dtos.Users;
using Caravan.Service.Interfaces;
using Caravan.Service.Interfaces.Common;
using Caravan.Service.Interfaces.Security;
using Microsoft.Extensions.Caching.Memory;
using System.Net;

namespace Caravan.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _repository;
        private readonly IAuthManager _authManager;
        private readonly IMemoryCache _memoryCache;
        private readonly IEmailService _emailService;
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork repository, IAuthManager authManager, IMemoryCache memoryCache, IImageService imageService, IEmailService emailService,IMapper mapper)
        {
            _repository = repository;
            _authManager = authManager;
            _memoryCache = memoryCache;
            _imageService = imageService;
            _emailService = emailService;
            _mapper = mapper;
        }

        public async Task<bool> AdminRegisterAsync(AdminCreateDto dto)
        {
            var emailcheck = await _repository.Administrators.FirstOrDefaultAsync(x => x.Email == dto.Email);
            if (emailcheck is not null)
                throw new StatusCodeException(HttpStatusCode.Conflict, "Email alredy exist");

            var phoneNumberCheck = await _repository.Administrators.FirstOrDefaultAsync(x => x.PhoneNumber == dto.PhoneNumber);
            if (phoneNumberCheck is not null)
                throw new StatusCodeException(HttpStatusCode.Conflict, "Phone number alredy exist");
            
            var hashresult = PasswordHasher.Hash(dto.Password);
            var admin = _mapper.Map<Administrator>(dto);
            admin.ImagePath = await _imageService.SaveImageAsync(dto.Image!);
            admin.PasswordHash = hashresult.passwordHash;
            admin.Salt = hashresult.salt;
            admin.CreatedAt = TimeHelper.GetCurrentServerTime();
            admin.UpdatedAt = TimeHelper.GetCurrentServerTime();
            _repository.Administrators.Add(admin);
            var result = await _repository.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteByPasswordAsync(UserDeleteDto userDeleteDto)
        {
            var user = await _repository.Users.FindByIdAsync(HttpContextHelper.UserId);
            if (user is null) throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");

            var res = PasswordHasher.Verify(userDeleteDto.Password, user.Salt, user.PasswordHash);
            if(res == false) throw new StatusCodeException(HttpStatusCode.NotFound, "Password is incorrect!");

            return true;
        }

        public async Task<string> LoginAsync(AccountLoginDto loginDto)
        {
            var user = await _repository.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email);
            if (user is null) throw new StatusCodeException(HttpStatusCode.NotFound, "User not found, Email is incorrect!");

            var hasherResult = PasswordHasher.Verify(loginDto.Password, user.Salt, user.PasswordHash);
            if (hasherResult)
            {
                return _authManager.GenerateToken(user);
            }
            else throw new StatusCodeException(HttpStatusCode.BadRequest, "Password is wrong!");
        }

        public async Task<bool> PasswordUpdateAsync(PasswordUpdateDto passwordUpdateDto)
        {
            var user = await _repository.Users.FindByIdAsync(HttpContextHelper.UserId);
            if (user is not null)
            {
                var result = PasswordHasher.Verify(passwordUpdateDto.OldPassword, user.Salt, user.PasswordHash);
                if (result)
                {
                    if (passwordUpdateDto.NewPassword == passwordUpdateDto.VerifyPassword)
                    {
                        var hash = PasswordHasher.Hash(passwordUpdateDto.VerifyPassword);
                        user.Salt = hash.salt;
                        user.PasswordHash = hash.passwordHash;
                        _repository.Users.Update(user.Id, user);
                        var res = await _repository.SaveChangesAsync();
                        return res > 0;
                    }
                    else throw new StatusCodeException(HttpStatusCode.BadRequest, "new password and verify password must be match");
                }
                else throw new StatusCodeException(HttpStatusCode.BadRequest, "Invalid Password");
            }
            else throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");

        }

        public async Task<bool> RegisterAsync(AccountRegisterDto registerDto)
        {
            var emailcheck = await _repository.Users.FirstOrDefaultAsync(x => x.Email == registerDto.Email);
            if (emailcheck is not null)
                throw new StatusCodeException(HttpStatusCode.Conflict, "Email alredy exist");

            var phoneNumberCheck = await _repository.Users.FirstOrDefaultAsync(x => x.PhoneNumber == registerDto.PhoneNumber);
            if (phoneNumberCheck is not null)
                throw new StatusCodeException(HttpStatusCode.Conflict, "Phone number alredy exist");

            var hasherResult = PasswordHasher.Hash(registerDto.Password);
            var user = (User)registerDto;
            user.PasswordHash = hasherResult.passwordHash;
            user.Role = Domain.Enums.UserRole.User;
            user.Salt = hasherResult.salt;
            user.CreatedAt = TimeHelper.GetCurrentServerTime();
            user.UpdatedAt = TimeHelper.GetCurrentServerTime();
            _repository.Users.Add(user);
            var databaseResult = await _repository.SaveChangesAsync();
            return databaseResult > 0;
        }

        public async Task SendCodeAsync(SendToEmailDto sendToEmail)
        {
            var user = await _repository.Users.FindByIdAsync(HttpContextHelper.UserId);
            if(user is null) throw new StatusCodeException(HttpStatusCode.NotFound, "User not found!");

            if(user.Email != sendToEmail.Email) throw new StatusCodeException(HttpStatusCode.BadRequest, "This email does not belong to you!");

            int code = new Random().Next(100000, 999999);
            _memoryCache.Set(sendToEmail.Email, code, TimeSpan.FromMinutes(10));

            var message = new EmailMessage()
            {
                To = sendToEmail.Email,
                Subject = "Verification code",
                Body = code.ToString()
            };

            await _emailService.SendAsync(message);
        }

        public async Task<bool> VerifyPasswordAsync(UserResetPasswordDto userResetPassword)
        {
            var user = await _repository.Users.GetByEmailAsync(userResetPassword.Email);
            if (user == null) throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");

            if (user.Email != userResetPassword.Email) throw new StatusCodeException(HttpStatusCode.BadRequest, "This email does not belong to you!");

            if (_memoryCache.TryGetValue(userResetPassword.Email, out int expectedCode) is false)
                throw new StatusCodeException(HttpStatusCode.BadRequest, "Code is expired");

            if (expectedCode != userResetPassword.Code)
                throw new StatusCodeException(HttpStatusCode.BadRequest, "Code is wrong");

            var newPassword = PasswordHasher.Hash(userResetPassword.Password);

            user.PasswordHash = newPassword.passwordHash;
            user.Salt = newPassword.salt;

            _repository.Users.Update(user.Id, user);

            var res = await _repository.SaveChangesAsync();

            return res > 0;
        }
    }
}
