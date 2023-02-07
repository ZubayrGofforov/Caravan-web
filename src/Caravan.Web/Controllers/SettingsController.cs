using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Caravan.Web.Controllers
{
    [Authorize]
    [Route("settings")]
    public class SettingsController : Controller
    {
        public IActionResult Index(long userId)
        {
            ViewBag.userSettingId=userId;
            return View();
        }
    }
}
