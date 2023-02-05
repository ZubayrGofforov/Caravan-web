using Caravan.Service.Dtos.Users;
using Caravan.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;

namespace Caravan.Web.Controllers;
public class UserController : Controller
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        this._userService = userService;
    }
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<ViewResult> Update(long userId)
    {
        var user = await _userService.GetAsync(userId);
        ViewBag.userId = userId;
        ViewBag.HomeTitle = "User / Update";
        var userUpdate = new UserUpdateDto()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Address = user.Address,
            PhoneNumber = user.PhoneNumber,
            Image = user.ImagePath,
        }
    }
}
