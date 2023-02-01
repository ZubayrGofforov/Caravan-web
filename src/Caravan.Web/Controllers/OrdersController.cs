using Caravan.Service.Common.Utils;
using Caravan.Service.Dtos.Orders;
using Caravan.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Caravan.Web.Controllers;

[Route("orders")]
[Authorize(Roles ="User")]
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

    [HttpGet("{orderId}")]
    public async Task<ViewResult> GetAsync(long orderId)
    {
        var product = await _orderService.GetAsync(orderId);
        return View(product);
    }

    [HttpGet("Create")]
    public ViewResult Create()
    {
        return View("OrderCreate");
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync([FromForm] OrderCreateDto createDto)
    {
        if (ModelState.IsValid)
        {
            var res = await _orderService.CreateAsync(createDto);
            if (res)
            {
                return RedirectToAction("Index", "Orders", new { area = "" });
            }
            else return Create();
        }
        else return Create();
    }       

    [HttpGet("update")]
    public ViewResult Update() => View("../Orders/OrderUpdate");

    [HttpPost("update")]
    public async Task<IActionResult> UpdateAsync([FromForm] OrderUpdateDto orderUpdateDto)
    {
        if (ModelState.IsValid)
        {
            var order = await _orderService.UpdateAsync(1, orderUpdateDto);
            if (order) return RedirectToAction("Index", "Orders", new { area = "" });
            else return Update();
        }
        else return Update();
    }
}
