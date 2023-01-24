using Microsoft.AspNetCore.Mvc;

namespace Caravan.Web.Controllers;
[Route("accounts")]
public class AccountsController : Controller
{
    [HttpGet("register")]
    public ViewResult Register()
    {
        return View("Register");
    }

    [HttpGet("login")]
    public ViewResult Login()
    {
        return View("Login");
    }
}
