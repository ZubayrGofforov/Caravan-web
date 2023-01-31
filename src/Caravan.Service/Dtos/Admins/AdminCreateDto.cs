using Caravan.Service.Common.Attributes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Caravan.Service.Dtos.Admins
{
    public class AdminCreateDto
    {
        [Required, MaxLength(25), MinLength(3)]
        public string FirstName { get; set; } = string.Empty;

        [Required, MaxLength(25), MinLength(3)]
        public string LastName { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false), PhoneNumberAttribute]
        public string PhoneNumber { get; set; } = string.Empty;

        [MaxLength(2)]
        public string PassportSeria { get; set; } = string.Empty;

        [MaxLength(7)]
        public string PassportNumber { get; set; } = string.Empty;

        [MaxFileSize(2)]
        [AllowedFiles(new string[] { ".jpg", ".png", ".jpeg", ".svg", ".webp" })]
        public IFormFile? Image { get; set; }

        [Required, EmailAttribute]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(8), StrongPassword]
        public string Password { get; set; } = string.Empty;
    }
}
