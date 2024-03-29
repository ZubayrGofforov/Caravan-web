﻿using Caravan.Domain.Entities;
using Caravan.Service.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Caravan.Service.Dtos.Accounts
{
    public class AccountRegisterDto
    {
        [Required, MaxLength(25), MinLength(3)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(25), MinLength(3)]
        public string LastName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false), PhoneNumberAttribute]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required, EmailAttribute]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(8), StrongPassword]
        public string Password { get; set; } = string.Empty;

        public static implicit operator User(AccountRegisterDto accountRegisterDto)
        {
            return new User()
            {
                Email = accountRegisterDto.Email,
                FirstName = accountRegisterDto.FirstName,
                LastName = accountRegisterDto.LastName,
                PhoneNumber = accountRegisterDto.PhoneNumber,
                Address = accountRegisterDto.Address
            };
        }
    }
}
