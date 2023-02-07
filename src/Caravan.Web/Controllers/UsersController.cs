using Caravan.Service.Dtos.Users;
using Caravan.Service.Interfaces;
using Caravan.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Caravan.Web.Controllers;
public class UsersController : Controller
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
        this._userService = userService;
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
}
