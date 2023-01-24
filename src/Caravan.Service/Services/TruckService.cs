using AutoMapper;
using Caravan.DataAccess.DbContexts;
using Caravan.DataAccess.Interfaces.Common;
using Caravan.DataAccess.Migrations;
using Caravan.Domain.Entities;
using Caravan.Service.Common.Attributes;
using Caravan.Service.Common.Exceptions;
using Caravan.Service.Common.Helpers;
using Caravan.Service.Common.Utils;
using Caravan.Service.Dtos.Locations;
using Caravan.Service.Dtos.Trucks;
using Caravan.Service.Interfaces;
using Caravan.Service.Interfaces.Common;
using Caravan.Service.ViewModels;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Service.Services
{
    public class TruckService : ITruckService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaginatorService _paginator;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;
        private readonly ILocationService _locationService;
      
        public TruckService(IUnitOfWork unitOfWork, IPaginatorService paginatorService, IMapper mapper, IImageService imageService, ILocationService locationService)
        {
            this._unitOfWork = unitOfWork;
            this._paginator = paginatorService;
            this._mapper = mapper;
            this._imageService = imageService;
            this._locationService = locationService;
        }

        public async Task<bool> CreateAsync(TruckCreateDto dto)
        {
            var user = await _unitOfWork.Users.FindByIdAsync(HttpContextHelper.UserId);
            if (user is null) throw new StatusCodeException(HttpStatusCode.NotFound, "User not found");

            var truck = _mapper.Map<Truck>(dto);
            truck.UserId = HttpContextHelper.UserId;
            truck.CreatedAt = TimeHelper.GetCurrentServerTime();
            truck.ImagePath = await _imageService.SaveImageAsync(dto.Image!);
            var res = await _locationService.CreateAsync(dto.TruckLocation);
            if (res.IsSuccessful) truck.LocationId = res.Id;
            else throw new StatusCodeException(HttpStatusCode.BadRequest, "Location is invalid");

            var r = await Task.Run(() => _unitOfWork.Trucks.Add(truck));
            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var truck = await _unitOfWork.Trucks.FindByIdAsync(id);
            if (truck is null) throw new StatusCodeException(HttpStatusCode.NotFound, "Truck not found");

            if (!string.IsNullOrEmpty(truck.ImagePath))
                await _imageService.DeleteImageAsync(truck.ImagePath);
            _unitOfWork.Trucks.Delete(id);

            var res = await _unitOfWork.SaveChangesAsync();
            return res > 0;
        }

        public async Task<IEnumerable<TruckViewModel>> GetAllAsync(PaginationParams @paginationParams)
        {
            var query = _unitOfWork.Trucks.GetAll().OrderBy(x => x.CreatedAt)
                .ToList().ConvertAll(x => _mapper.Map<TruckViewModel>(x));
            var data = await _paginator.ToPagedAsync(query, @paginationParams.PageNumber, @paginationParams.PageSize);
            return data;
        }

        public async Task<IEnumerable<TruckViewModel>> GetAllByIdAsync(long id, PaginationParams @paginationParams)
        {
            if (id != HttpContextHelper.UserId)
                throw new StatusCodeException(HttpStatusCode.BadRequest, "You are not allowed to view this id information, your information");
            var trucks = await Task.Run(() => _unitOfWork.Trucks.Where(x => x.UserId == HttpContextHelper.UserId).ToListAsync());
            var result = await Task.Run(() => trucks.Where(x => x.Id == HttpContextHelper.UserId)
                                                    .ToList().ConvertAll(x => _mapper.Map<TruckViewModel>(x)));
            
            if (result is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Truck not found");
            else
            {
                var data = await _paginator.ToPagedAsync(result, paginationParams.PageNumber, paginationParams.PageSize);
                return data;
            }
        }

        public async Task<TruckViewModel> GetAsync(long id)
        {
            var truck = await _unitOfWork.Trucks.FindByIdAsync(id);
            if (truck is not null)
                return _mapper.Map<TruckViewModel>(truck);
            else throw new StatusCodeException(HttpStatusCode.NotFound, "Track not found");
        }

        public async Task<IEnumerable<TruckViewModel>> GetLocationNameAsync(string locationName, PaginationParams @paginationParams)
        {
            var trucks = await Task.Run(() => _unitOfWork.Trucks.Where(x => x.LocationName.ToLower() == locationName.ToLower()).ToListAsync());
            var result = await Task.Run(() => trucks.Where(x => x.LocationName.ToLower() == locationName.ToLower())
                                                    .ToList().ConvertAll(x => _mapper.Map<TruckViewModel>(x)));
            if (result is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Truck not found");
            else
            {
                var data = await _paginator.ToPagedAsync(result, paginationParams.PageNumber, paginationParams.PageSize);
                return data;
            }
        }

        public async Task<bool> TruckStatusUpdateAsync(long id, TruckStatusDto dto)
        {
            var truck = await _unitOfWork.Trucks.FindByIdAsync(id);
            if (truck is null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Truck not found");

            if (truck.UserId == HttpContextHelper.UserId || HttpContextHelper.UserRole != "User")
            {
                _unitOfWork.Trucks.TrackingDeteched(truck);
                truck.IsEmpty = dto.IsEmpty;
                _unitOfWork.Trucks.Update(id, truck);
                var res = await _unitOfWork.SaveChangesAsync();
                return res > 0;
            }
                throw new StatusCodeException(HttpStatusCode.BadRequest, "Not allowed");
        }
        public async Task<bool> UpdateAsync(long id, TruckUpdateDto updateDto)
        {
            var truck = await _unitOfWork.Trucks.FindByIdAsync(id);
            if (truck is null) throw new StatusCodeException(HttpStatusCode.NotFound, "Truck not found");

            if(HttpContextHelper.UserId == truck.UserId || HttpContextHelper.UserRole != "User")
            {
                _unitOfWork.Trucks.TrackingDeteched(truck);
                truck.Name= updateDto.Name;

                truck.TruckNumber = updateDto.TruckNumber;
                truck.UserId = HttpContextHelper.UserId;
                truck.Description= updateDto.Description;

                if (updateDto.Image is not null)
                {
                    await _imageService.DeleteImageAsync(truck.ImagePath!);
                    truck.ImagePath = await _imageService.SaveImageAsync(updateDto.Image);
                }

                truck.LocationName = string.IsNullOrWhiteSpace(updateDto.LocationName) ? truck.LocationName : updateDto.LocationName; ;
                _unitOfWork.Trucks.Update(id, truck);
                var result = await _unitOfWork.SaveChangesAsync();
                return result > 0;
            }
            else throw new StatusCodeException(HttpStatusCode.BadRequest, "Not allowed");
            
        }

        public async Task<bool> UpdateLocationAsync(long id, LocationCreateDto dto)
        {
            var truck = await _unitOfWork.Trucks.FindByIdAsync(id);
            if (truck.UserId == HttpContextHelper.UserId || HttpContextHelper.UserRole != "User")
            {
                bool res =await _locationService.UpdateAsync(truck.LocationId, dto);
                return res;
            }
            else throw new StatusCodeException(HttpStatusCode.BadRequest, "Not allowed");
        }
    }
}
