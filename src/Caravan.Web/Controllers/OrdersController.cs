using Caravan.Service.Common.Helpers;
using Caravan.Service.Common.Utils;
using Caravan.Service.Dtos.Locations;
using Caravan.Service.Dtos.Orders;
using Caravan.Service.Interfaces;
using Caravan.Service.ViewModels;
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
        ViewBag.HomeTitle = "Orders";
        return View("Index", orders);
    }

    [HttpGet("{orderId}")]
    public async Task<ViewResult> GetAsync(long orderId)
    {
        var product = await _orderService.GetAsync(orderId);
        ViewBag.HomeTitle = "Orders / Get";
        return View(product);
    }

    [HttpGet("OwnerOrders")]
    public async Task<ViewResult> GetAllByIdAsync(int page = 1)    
    {
        long ownerId = HttpContextHelper.UserId;
        var orders = await _orderService.GetAllByIdAsync(ownerId, new PaginationParams(page, _pageSize));
        return View("OwnerOrders", orders);
    }
    [HttpGet("Create")]
    public ViewResult Create()
    {
        ViewBag.HomeTitle = "Orders / Create";
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
        return View("../Orders/OrderUpdate",orderUpdate);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateAsync([FromForm] OrderUpdateDto orderUpdateDto, long orderId)
    {
        if (ModelState.IsValid)
        {
            var order = await _orderService.UpdateAsync(orderId, orderUpdateDto);
            if (order) return RedirectToAction("Index", "Orders", new { area = "" });
            else return RedirectToAction("Index", "Orders", new { area = "" });
        }
        else return await Update(orderId);
    }

    [HttpGet("delete")]
    public async Task<IActionResult> DeleteAsync(long deleteOrderId)
    {
        var result = await _orderService.DeleteAsync(deleteOrderId);
        if (result) return RedirectToAction("Index", "Orders", new { area = "" });
        else return await GetAsync(deleteOrderId);
    }
}
