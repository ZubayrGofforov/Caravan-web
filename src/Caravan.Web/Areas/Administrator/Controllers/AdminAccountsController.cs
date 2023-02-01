using Caravan.Service.Common.Exceptions;
using Caravan.Service.Dtos.Accounts;
using Caravan.Service.Dtos.Admins;
using Caravan.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Caravan.Web.Areas.Administrator.Controllers;
[Route("adminAccounts")]
public class AdminAccountsController : BaseController
{
    private readonly IAccountService _accountService;
    public AdminAccountsController(IAccountService accountService)
    {
        this._accountService = accountService;
    }

    [HttpGet("adminRegister")]
    public ViewResult AdminRegister() => View("../Accounts/AdminRegister");

    [HttpPost("adminRegister")]
    public async Task<IActionResult> AdminRegisterAsync([FromForm] AdminCreateDto adminCreateDto)
    {
        if(ModelState.IsValid)
        {
            bool result = await _accountService.AdminRegisterAsync(adminCreateDto);
            if(result)
            {
                return RedirectToAction("adminLogin", "adminAccounts", new { area = "" });
            }
            else
            {
                return AdminRegister();
            }
        }
        else
        {
            return AdminRegister();
        }
     
    }
     
     
    [HttpGet("adminLogin")]
    public ViewResult Login()
    {
        return View("../Accounts/AdminLogin");
    }
    
    [HttpPost("adminLogin")]
    public async Task<IActionResult> LoginAsync(AccountLoginDto accountLoginDto)
    {
        if (ModelState.IsValid)
        {
            try
            {
                string token = await _accountService.LoginAsync(accountLoginDto);
                HttpContext.Response.Cookies.Append("X-Access-Token", token, new CookieOptions()
                {
                    HttpOnly= true,
                    SameSite = SameSiteMode.Strict
                });
                return RedirectToAction("Index", "../Home", new { area = "" });
            }
            catch (ModelErrorException modelError)
            {
                ModelState.AddModelError(modelError.Property, modelError.Message);
                return Login();
            }
            catch
            {
                return Login();
            }
        }
        else
        {
            return Login();
        }
    }
}
