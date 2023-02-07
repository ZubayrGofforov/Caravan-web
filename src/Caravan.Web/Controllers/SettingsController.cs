using Microsoft.AspNetCore.Mvc;

namespace Caravan.Web.Controllers
{
    [Route("settings")]
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
