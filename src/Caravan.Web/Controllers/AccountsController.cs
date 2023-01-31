using Caravan.Service.Common.Exceptions;
using Caravan.Service.Common.Helpers;
using Caravan.Service.Dtos.Accounts;
using Caravan.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Caravan.Web.Controllers;
[Route("accounts")]
public class AccountsController : Controller
{
    private readonly IAccountService _service;

    public AccountsController(IAccountService accountService)
    {
        this._service = accountService;
    }


    [HttpGet("register")]
    public ViewResult Register()
    {
        return View("Register");
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(AccountRegisterDto accountRegisterDto)
    {
        if (ModelState.IsValid)
        {
            bool result = await _service.RegisterAsync(accountRegisterDto);
            if (result)
            {
                return RedirectToAction("login", "accounts", new { area = "" });
            }
            else
            {
                return Register();
            }
        }
        else return Register();
    }


    [HttpGet("login")]
    public ViewResult Login() => View("Login");

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(AccountLoginDto accountLoginDto)
    {
        if (ModelState.IsValid)
        {
            try
            {
                string token = await _service.LoginAsync(accountLoginDto);
                HttpContext.Response.Cookies.Append("X-Access-Token", token, new CookieOptions()
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict
                });
                return RedirectToAction("Index", "Home", new { area = "" });
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
        else return Login();
    }

    [HttpGet("logout")]
    public IActionResult LogOut()
    {
        HttpContext.Response.Cookies.Append("X-Access-Token", "", new CookieOptions()
        {
            Expires = TimeHelper.GetCurrentServerTime().AddDays(-1)
        });
        return RedirectToAction("Index", "Home", new { area = "" });
    }
}
