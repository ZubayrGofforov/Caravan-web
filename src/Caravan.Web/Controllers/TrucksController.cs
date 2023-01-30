using Caravan.Service.Common.Utils;
using Caravan.Service.Dtos.Trucks;
using Caravan.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Caravan.Web.Controllers;

[Route("trucks")]
public class TrucksController : Controller
{
    private readonly ITruckService _service;
    private readonly int _pageSize = 20;
    public TrucksController(ITruckService service)
    {
        this._service = service;
    }
    public async Task<ViewResult> GetAllAsync(int page = 1)
    {
        var trucks = await _service.GetAllAsync(new PaginationParams(page, _pageSize));
        return View("Index",trucks);
    }

    [HttpGet("truckId")]
    public async Task<ViewResult> GetAsync(long truckId)
    {
        var truck = await _service.GetAsync(truckId);
        return View(truck);
    }

    // Davomi yoziladi!
    [HttpPost("truckId")]
    public async Task<IActionResult> DeleteAsync(long truckId)
    {
        var truck = await _service.DeleteAsync(truckId);
        if (truck) return RedirectToAction("Index", "Trucks", new { area = "" });
        else throw new Exception();
    }

    [HttpGet("Create")]
    public ViewResult Create()
    {
        return View("TruckCreate");
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(TruckCreateDto createDto)
    {
        if (ModelState.IsValid)
        {
            var res = await _service.CreateAsync(createDto);
            if (res)
            {
                return RedirectToAction("Index", "Trucks", new { area = "" });
            }
            else return Create();
        }
        else return Create();
    }
}
