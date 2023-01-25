using Caravan.Service.Interfaces.Common;
using Caravan.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Caravan.Web.ViewComponents;

public class IdentityViewComponent : ViewComponent
{
    private readonly IIdentityService _identityService;

    public IdentityViewComponent(IIdentityService identityService)
    {
        this._identityService = identityService;
    }
    public IViewComponentResult Invoke()
    {
        UserViewModel model = new UserViewModel()
        {
            Id = _identityService.Id!.Value,
            Email = _identityService.Email,
            FirstName = _identityService.FirstName,
            LastName = _identityService.LastName,
        };
        return View(model);
    }
}
