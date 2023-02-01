using AutoMapper;
using Caravan.Service.Common.Utils;
using Caravan.Service.Dtos.Trucks;
using Caravan.Service.Interfaces;
using Caravan.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Caravan.Web.Controllers;

[Route("trucks")]
public class TrucksController : Controller
{
    private readonly ITruckService _service;
    private readonly int _pageSize = 20;
    private readonly IMapper _mapper;
    public TrucksController(ITruckService service, IMapper _mapper)
    {
        this._service = service;
        this._mapper = _mapper;

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

    [HttpPost("Create")]
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

    [HttpGet("Update")]
    public async Task<IActionResult> UpdateRedirectAsync(long id)
    {
        var truck = await _service.GetAsync(id);
        truck.Id = id;
        var dto = new TruckUpdateDto()
        {
            Id = id,
            Name = truck.Name,
            Description = truck.Description,
            TruckNumber = truck.TruckNumber,
            MaxLoad = truck.MaxLoad,
            LocationName = truck.LocationName
        };
        ViewBag.truckId = id;
        return View("Update", dto);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> UpdateAsync(long id, TruckUpdateDto updateDto)
    {
        var res = await _service.UpdateAsync(id,updateDto);
        if (res)
            return RedirectToAction("Index", "Trucks", new { area = "" });

        else return  await UpdateRedirectAsync(id);
    }
    
}
