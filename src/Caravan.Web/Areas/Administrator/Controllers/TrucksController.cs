using Caravan.Service.Common.Utils;
using Caravan.Service.Dtos.Trucks;
using Caravan.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Caravan.Web.Areas.Administrator.Controllers;

[Route("adminTrucks")]
public class TrucksController : BaseController
{
    private readonly ITruckService _truckService;
    private readonly int _pageSize = 20;
    public TrucksController(ITruckService truckService)
    {
        this._truckService = truckService;
    }
    public async Task<ViewResult> Index(int page = 1)
    {
        var trucks = await _truckService.GetAllAsync(new PaginationParams(page, _pageSize));
        return View("Index", trucks);
    }

    [HttpGet("create")]
    public ViewResult Create() => View("TruckCreate");
    [HttpPost("create")]
    public async Task<IActionResult> CreateAsync([FromForm] TruckCreateDto truckCreateDto)
    {
        if (ModelState.IsValid)
        {
            bool truck = await _truckService.CreateAsync(truckCreateDto);
            if (truck)
                return RedirectToAction("Index", "Trucks", new { area = "adminstrator" });
            else
                return Create();
        }
        else return Create();
    }  

    [HttpGet("truckId")]
    public async Task<ViewResult> GetAsync(long truckId)
    {
        var truck = await _truckService.GetAsync(truckId);
        return View(truck);
    }
    [HttpGet("Update")]
    public async Task<IActionResult> UpdateRedirectAsync(long truckid)
    {
        var truck = await _truckService.GetAsync(truckid);
        truck.Id = truckid;
        var dto = new TruckUpdateDto()
        {
            Id = truckid,
            Name = truck.Name,
            Description = truck.Description,
            TruckNumber = truck.TruckNumber,
            MaxLoad = truck.MaxLoad,
            LocationName = truck.LocationName
        };
        ViewBag.truckId = truckid;
        ViewBag.HomeTitle = "Orders / Get / Update";
        return View("TruckUpdate", dto);
    }

    [HttpGet("Delete")]
    public async Task<IActionResult> DeleteAsync(long truckid)
    {
        var res = await _truckService.DeleteAsync(truckid);
        if (res)
        {
            return RedirectToAction("Index", "Trucks",  new { area = "Adminstrator" });
        }
        return RedirectToAction("Index", "Trucks", new { area = "Adminstrator" });
    }

}
