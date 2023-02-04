using Caravan.Service.Common.Attributes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Caravan.Service.Dtos.Users
{
    public class UserUpdateDto
    {
        [Required, MaxLength(30), MinLength(3)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(30), MinLength(3)]
        public string LastName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false), PhoneNumberAttribute]
        public string PhoneNumber { get; set; } = string.Empty;

        public IFormFile? Image { get; set; }
    }
}
