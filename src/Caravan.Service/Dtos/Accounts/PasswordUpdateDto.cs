using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Service.Dtos.Accounts;

public class PasswordUpdateDto
{
    [Required(ErrorMessage = ("Enter old Password"))]
    public string OldPassword { get; set; } = default!;

    [Required(ErrorMessage = ("Enter new Password"))]
    public string NewPassword { get; set; } = default!;

    [Required(ErrorMessage = ("Enter verify Password"))]
    public string VerifyPassword { get; set; } = default!;
}
