using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Caravan.Web.Areas.Administrator.Controllers;
[Authorize("Admin")]

public class HomeController : BaseController
{
    public IActionResult Index()
    {
        return View();
    }
}
