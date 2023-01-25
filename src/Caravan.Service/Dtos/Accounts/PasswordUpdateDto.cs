using System.ComponentModel.DataAnnotations;

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
