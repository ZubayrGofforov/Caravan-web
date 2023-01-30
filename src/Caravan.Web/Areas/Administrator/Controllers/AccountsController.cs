using Caravan.Service.Dtos.Admins;
using Caravan.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Caravan.Web.Areas.Administrator.Controllers;
[Route("adminAccounts")]
public class AccountsController : BaseController
{
    private readonly IAccountService _accountService;

    public AccountsController(IAccountService accountService)
    {
        this._accountService = accountService;
    }

    [HttpGet("adminRegister")]
    public ViewResult Register()
    {
        return View("AdminRegister");
    }


    [HttpGet("adminLogin")]
    public ViewResult Login()
    {
        return View("AdminLogin");
    }
}
