using AutoMapper;
using Caravan.Domain.Common;
using Caravan.Domain.Entities;
using Caravan.Service.Dtos.Locations;
using Caravan.Service.Dtos.Orders;
using Caravan.Service.Dtos.Trucks;
using Caravan.Service.Dtos.Users;
using Caravan.Service.ViewModels;

namespace Caravan.Api.Configuration
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<TruckCreateDto, Truck>().ReverseMap();
            CreateMap<TruckViewModel, Truck>().ReverseMap();
            CreateMap<OrderCreateDto, Order>().ReverseMap();
            CreateMap<UserViewModel, User>().ReverseMap();
            CreateMap<OrderViewModel, Order>().ReverseMap();
            CreateMap<LocationCreateDto, Location>().ReverseMap();
            CreateMap<LocationViewModel, Location>().ReverseMap();
            CreateMap<UserUpdateDto, User>();
            CreateMap<TruckStatusDto, Truck>().ReverseMap();
            CreateMap<OrderUpdateDto, Order>();
            CreateMap<TruckUpdateDto, Truck>();
        }
    }
}
