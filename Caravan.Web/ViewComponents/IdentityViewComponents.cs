using Caravan.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Caravan.Web.ViewComponents;

public class IdentityViewComponents : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        UserViewModel model = new UserViewModel()
        {
            FirstName = "Fazliddin",
            LastName = "Mustafoyev",

        };
        return View(model);
    }
}
