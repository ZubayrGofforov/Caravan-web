using Caravan.Service.Dtos.Accounts;
using Caravan.Service.Dtos.Users;
using Caravan.Service.Interfaces;
using Caravan.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Caravan.Web.Controllers;
public class UsersController : Controller
{
    private readonly IUserService _userService;
    private readonly IAccountService _accountService;

    public UsersController(IUserService userService, IAccountService accountService)
    {
        this._userService = userService;
        this._accountService = accountService;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<ViewResult> Get(long userId)
    {
        var user = await _userService.GetAsync(userId);
        ViewBag.UserId = userId;
        ViewBag.HomeTitle = "My account";
        var userView = new UserViewModel()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Address = user.Address,
            PhoneNumber = user.PhoneNumber,
            Email = user.Email
        };
        return View("../Users/Index", user);
    }

    [HttpGet]
    public async Task<ViewResult> Update(long userId)
    {
        var user = await _userService.GetAsync(userId);
        ViewBag.userId = userId;
        ViewBag.HomeTitle = "User update";
        var userUpdate = new UserUpdateDto()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Address = user.Address,
            PhoneNumber = user.PhoneNumber,
        };
        return View("../Users/Update", userUpdate);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateAsync([FromForm] UserUpdateDto userUpdateDto, long userId)
    {
        if (ModelState.IsValid)
        {
            var user = await _userService.UpdateAsync(userId, userUpdateDto);
            if (user) return RedirectToAction("Index", "Home", new { area = "" });
            else return RedirectToAction("Update", "Users", new { area = "" });
        }
        else return RedirectToAction("Update", "Users", new { area = "" });
    }

    // View lari yozilmagan Parolini bilganda yangilash -->
    [HttpGet]
    public async Task<ViewResult> UpdatePasswordAsync()
    {
        return View("UpdatePassword");
    }

    [HttpPost]
    public async Task<IActionResult> UpdatePassword(PasswordUpdateDto passwordUpdateDto)
    {
        if (ModelState.IsValid)
        {
            var result = await _accountService.PasswordUpdateAsync(passwordUpdateDto);
            if (result) return RedirectToAction("Index", "settings");
            else return RedirectToAction();
        }
        else return RedirectToAction();
    }
    // <--

    // View lari yozilmagan Emailga code jo'natish
    [HttpGet]
    public async Task<ViewResult> SendEmailAsync()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> SendEmailAsync(SendToEmailDto sendToEmailDto)
    {
        if (ModelState.IsValid)
        {
            await _accountService.SendCodeAsync(sendToEmailDto);
            return RedirectToAction("ForgetPassword", "Users");
        }
        else return RedirectToAction();
    }
    // <--

    [HttpGet]
    public async Task<ViewResult> ForgetPasswordAsync()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ForgetPasswordAsync(UserResetPasswordDto resetPasswordDto)
    {
        if (ModelState.IsValid)
        {
            var res = await _accountService.VerifyPasswordAsync(resetPasswordDto);
            if (res) return RedirectToAction("Index", "settings");

            else return RedirectToAction();
        }
        else return RedirectToAction();
    }
}
