using Caravan.Service.Common.Utils;
using Caravan.Service.Dtos.Trucks;
using Caravan.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Caravan.Web.Areas.Administrator.Controllers;
[Route("admintrucks")]
public class TrucksController : BaseController
{
    private readonly ITruckService _truckService;
    private readonly int _pageSize = 20;
    public TrucksController(ITruckService truckService)
    {
        this._truckService = truckService;
    }

    [HttpGet("create")]
    public ViewResult Create() => View("TruckCreate");
    public async Task<IActionResult> CreateAsync([FromForm] TruckCreateDto truckCreateDto)
    {
        if(ModelState.IsValid)
        {
            bool truck = await _truckService.CreateAsync(truckCreateDto);
            if (truck)
                return RedirectToAction("Index", "Trucks", new { area = "" });
            else
                return Create();
        }
        else return Create();
    }

    public async Task<ViewResult> Index(int page = 1)
    {
        var trucks = await _truckService.GetAllAsync(new PaginationParams(page, _pageSize));
        return View(trucks);
    }

    [HttpGet("truckId")]
    public async Task<ViewResult> GetAsync(long truckId)
    {
        var truck = await _truckService.GetAsync(truckId);
        return View(truck);
    }
}
