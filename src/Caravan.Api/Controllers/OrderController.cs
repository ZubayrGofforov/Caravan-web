using Caravan.Service.Common.Utils;
using Caravan.Service.Dtos.Orders;
using Caravan.Service.Dtos.Trucks;
using Caravan.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Caravan.Api.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;
        private readonly int _pageSize = 20;
        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetAllAsync(int page)
            => Ok(await _service.GetAllAsync(new PaginationParams(page, _pageSize)));


        [HttpGet("locationName"), AllowAnonymous]
        public async Task<IActionResult> GetLocationNameAsync(string locationName, [FromQuery] int page)
            => Ok(await _service.GetLocationNameAsync(locationName, new PaginationParams(page, _pageSize)));

        
        [HttpGet("{orderId}"), Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetByIdAsync(long orderId)
            => Ok(await _service.GetAsync(orderId));

        
        [HttpPost, Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> CreateAsync([FromForm] OrderCreateDto dto)
            => Ok(await _service.CreateAsync(dto));

        
        [HttpDelete("{orderId}"), Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> DeleteAsync(long orderId)
            => Ok( await _service.DeleteAsync(orderId));

        
        [HttpPut("{orderId}"), Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> UpdateAsync(long orderId, [FromForm] OrderUpdateDto dto)
            => Ok(await _service.UpdateAsync(orderId, dto));

        
        [HttpPatch("{orderId}/updateStatus"), Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> UpdateStatusAsync(long orderId, [FromForm] OrderStatusDto dto)
            => Ok(await _service.UpdateStatusAsync(orderId, dto));

        
        [HttpGet("allbyid/{userId}"), Authorize(Roles = "User")]
        public async Task<IActionResult> GetAllByIdAsync(long userId, [FromQuery] int page)
            => Ok(await _service.GetAllByIdAsync(userId, new PaginationParams(page, _pageSize)));
    }
}
