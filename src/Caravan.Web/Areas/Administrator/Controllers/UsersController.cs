using Caravan.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Caravan.Service.Common.Utils;

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
    }
}
