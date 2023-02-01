using Caravan.Service.Dtos.Admins;
using Caravan.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Caravan.Web.Areas.Administrator.Controllers;
public class AccountsController : BaseController
{
    private readonly IAccountService _accountService;
    public AccountsController(IAccountService accountService)
    {
        this._accountService = accountService;
    }

    public ViewResult Register() => View("Register");

    [HttpPost]
    public async Task<IActionResult> RegisterAsync([FromForm] AdminCreateDto adminCreateDto)
    {
        if (ModelState.IsValid)
        {
            bool result = await _accountService.AdminRegisterAsync(adminCreateDto);
            if (result)
            {
                return RedirectToAction("Login", "AdminAccounts", new { area = "administrator" });
            }
            else
            {
                return Register();
            }
        }
        else
        {
            return Register();
        }
    }
}
