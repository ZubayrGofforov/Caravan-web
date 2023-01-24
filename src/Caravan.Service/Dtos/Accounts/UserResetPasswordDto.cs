using Caravan.Service.Common.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Service.Dtos.Accounts
{
    public class UserResetPasswordDto
    {
        [Required(ErrorMessage = "Email is required!"), EmailAttribute]
        public string Email { get; set; } = string.Empty;

        [Required]
        public int Code { get; set; }

        [Required, StrongPassword]
        public string Password { get; set; } = string.Empty;
    }
}
