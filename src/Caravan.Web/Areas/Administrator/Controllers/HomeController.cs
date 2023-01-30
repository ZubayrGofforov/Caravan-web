using Microsoft.AspNetCore.Mvc;

namespace Caravan.Web.Areas.Administrator.Controllers;
public class HomeController : BaseController
{
    public IActionResult Index()
    {
        return View();
    }
}
