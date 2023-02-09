using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Caravan.Web.Areas.Administrator.Controllers;
[Area("administrator")]
[Authorize(Roles = "Admin")]
public class BaseController : Controller
{
   
}
