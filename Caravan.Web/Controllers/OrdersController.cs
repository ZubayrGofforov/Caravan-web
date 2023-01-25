using Caravan.Service.Common.Utils;
using Caravan.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Caravan.Web.Controllers;

[Route("orders")]
public class OrdersController : Controller
{
    private readonly IOrderService _orderService;
    private readonly int _pageSize = 20;
    public OrdersController(IOrderService orderService)
    {
        this._orderService = orderService;
    }
    public async Task<ViewResult> Index(int page = 1)
    {
        var orders = await _orderService.GetAllAsync(new PaginationParams(page, _pageSize));
        return View("Index", orders);
    }
}
