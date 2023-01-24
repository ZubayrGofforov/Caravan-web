using AutoMapper;
using Caravan.DataAccess.DbContexts;
using Caravan.DataAccess.Interfaces.Common;
using Caravan.Domain.Common;
using Caravan.Service.Common.Exceptions;
using Caravan.Service.Dtos.Locations;
using Caravan.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Service.Services
{
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LocationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<(bool IsSuccessful, long Id)> CreateAsync(LocationCreateDto createDto)
        {
            var res = _unitOfWork.Locations.Add(_mapper.Map<Location>(createDto));
            var result = await _unitOfWork.SaveChangesAsync();
            return result > 0 ? (true,res.Id) : (false, res.Id);
        }

        public async Task<bool> UpdateAsync(long id, LocationCreateDto updateDto)
        {
            var location = await _unitOfWork.Locations.FindByIdAsync(id);
            if (location == null)
                throw new StatusCodeException(HttpStatusCode.NotFound, "Location not found");

            _unitOfWork.Locations.TrackingDeteched(location);

            location.Id = id;
            location.Latitude = updateDto.Latitude;
            location.Longitude = updateDto.Longitude;

            _unitOfWork.Locations.Update(id, location);

            var result = await _unitOfWork.SaveChangesAsync();

            return result > 0;
        }
    }
}
