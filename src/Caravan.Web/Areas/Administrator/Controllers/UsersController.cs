using Caravan.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Caravan.Service.Common.Utils;
using Caravan.Service.Dtos.Trucks;
using Caravan.Service.Services;
using Caravan.Service.Dtos.Users;

namespace Caravan.Web.Areas.Administrator.Controllers
{
    [Route("adminUsers")]
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;
        private readonly int pageSize = 20;
        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }
        public async Task<ViewResult> Index(int page =1)
        {
            var users = await _userService.GetAllAysnc(new PaginationParams(page, pageSize));
            return View("Index", users);
        }

        [HttpGet("Update")]
        public async Task<IActionResult> UpdateRedirectAsync(long userid)
        {
            var user = await _userService.GetAsync(userid);
            user.Id = userid;
            var upuser = new UserUpdateDto()
            {
                FirstName = user.FirstName,
                LastName= user.LastName,
                Address= user.Address,
                PhoneNumber= user.PhoneNumber,
            };
            ViewBag.userid = userid;
            ViewBag.HomeTitle = "user / Get / Update";
            return View("UserUpdate", upuser);
        }
        [HttpGet("Delete")]
        public async Task<IActionResult> DeleteAsync(long userid)
        {
            var res = await _userService.DeleteAsync(userid);
            if (res)
            {
                return RedirectToAction("Index", "Trucks", new { area = "Adminstrator" });
            }
            return RedirectToAction("Index", "Trucks", new { area = "Adminstrator" });
        }

    }

}
