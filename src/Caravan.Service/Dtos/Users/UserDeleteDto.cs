using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Service.Dtos.Users
{
    public class UserDeleteDto
    {
        [Required(ErrorMessage = "Enter your password")]
        public string Password { get; set; } = default!;
    }
}
