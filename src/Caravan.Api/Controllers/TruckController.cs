using Caravan.Service.Common.Utils;
using Caravan.Service.Dtos.Locations;
using Caravan.Service.Dtos.Trucks;
using Caravan.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace Caravan.Api.Controllers
{
    [Route("api/trucks")]
    [ApiController]
    public class TruckController : ControllerBase
    {
        private readonly ITruckService _service;
        private readonly int pageSize = 20;
        public TruckController(ITruckService truckService)
        {
            this._service = truckService;
        }

        [HttpGet("locationName"), AllowAnonymous]
        public async Task<IActionResult> GetLocationNameAsync(string locationName, [FromQuery] int page)
            => Ok(await _service.GetLocationNameAsync(locationName, new PaginationParams(page, pageSize)));


        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> GetAllAsync(int page)
            => Ok(await _service.GetAllAsync(new PaginationParams(page, pageSize)));

        
        [HttpPost, Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> CreateAsync([FromForm] TruckCreateDto dto)
            => Ok(await _service.CreateAsync(dto));

        
        [HttpGet("{truckId}"), Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> GetByIdAsync(long truckId)
            => Ok(await _service.GetAsync(truckId));

        
        [HttpDelete("{truckId}"), Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> DeleteAsync(long truckId)
            => Ok(await _service.DeleteAsync(truckId));

        
        [HttpPatch("{truckId}/updatestatus"), Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> UpdateStatusAsync(long truckId, TruckStatusDto status)
            => Ok(await _service.TruckStatusUpdateAsync(truckId, status));

        
        [HttpPut("{truckId}"), Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> UpdateAsync(long truckId, [FromForm] TruckUpdateDto truckUpdateDto)
            => Ok(await _service.UpdateAsync(truckId, truckUpdateDto));

        
        [HttpPatch("{truckId}/updatelocation"), Authorize(Roles ="User")]
        public async Task<IActionResult> UpdateLocationAsync(long id, LocationCreateDto dto)
            => Ok(await _service.UpdateLocationAsync(id, dto));

        
        [HttpGet("allbyid/{userId}"), Authorize(Roles = "Admin, User")]
        public async Task<IActionResult> GetAllByIdAsync(long userId, [FromQuery]int page)
            => Ok(await _service.GetAllByIdAsync(userId, new PaginationParams(page, pageSize)));
    }
}
