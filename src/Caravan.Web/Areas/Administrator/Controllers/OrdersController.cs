using Caravan.Service.Common.Utils;
using Caravan.Service.Dtos.Orders;
using Caravan.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Caravan.Web.Areas.Administrator.Controllers;

[Route("adminOrders")]
public class OrdersController : BaseController
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
        return View("Index",orders);
    }

    [HttpGet("orderId")]
    public async Task<ViewResult> GetAsync(long orderId)
    {
        var order = await _orderService.GetAsync(orderId);
        return View(order);
    }

    [HttpGet("create")]
    public ViewResult Create() => View("OrderCreate");

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] OrderCreateDto orderCreateDto)
    {
        if (ModelState.IsValid)
        {
            bool order = await _orderService.CreateAsync(orderCreateDto);
            if (order)
                return RedirectToAction("Index", "Orders", new { area = "" });
            else
                return Create();
        }
        else return Create();
    }

}
