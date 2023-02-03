using Caravan.Service.Common.Utils;
using Caravan.Service.Dtos.Locations;
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
    [HttpGet("update")]
    public async Task<ViewResult> Update(long orderId)
    {
        var order = await _orderService.GetAsync(orderId);
        ViewBag.orderId = orderId;
        ViewBag.HomeTitle = "Orders / Get / Update";
        var orderUpdate = new OrderUpdateDto()
        {
            Name = order.Name,
            Price = order.Price,
            Weight = order.Weight,
            Size = order.Size,
            LocationName = order.LocationName,
            TransferLocation = new LocationCreateDto()
            {
                Latitude = order.TakenLocation.Latitude,
                Longitude = order.TakenLocation.Longitude,
            },
            CurrentlyLocation = new LocationCreateDto()
            {
                Latitude = order.DeliveryLocation.Latitude,
                Longitude = order.DeliveryLocation.Longitude,
            },
        };
        return View("OrderUpdate", orderUpdate);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateAsync([FromForm] OrderUpdateDto orderUpdateDto, long orderId)
    {
        if (ModelState.IsValid)
        {
            var order = await _orderService.UpdateAsync(orderId, orderUpdateDto);
            if (order) return RedirectToAction("Index", "adminOrders", new { area = "Adminstrator" });
            else return RedirectToAction("Index", "adminOrders", new { area = "Adminstrator" });
        }
        else return await Update(orderId);
    }

    [HttpGet("delete")]
    public async Task<IActionResult> DeleteAsync(long orderId)
    {
        var result = await _orderService.DeleteAsync(orderId);
        if (result) return RedirectToAction("Index", "adminOrders", new { area = "Adminstrator" });
        else return await GetAsync(orderId);
    }

}
