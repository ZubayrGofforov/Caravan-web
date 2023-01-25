using Caravan.Service.Common.Utils;
using Caravan.Service.Dtos.Locations;
using Caravan.Service.Dtos.Trucks;
using Caravan.Service.ViewModels;

namespace Caravan.Service.Interfaces
{
    public interface ITruckService
    {
        public Task<IEnumerable<TruckViewModel>> GetAllAsync(PaginationParams @paginationParams);

        public Task<TruckViewModel> GetAsync(long id);

        public Task<bool> DeleteAsync(long id);

        public Task<bool> CreateAsync(TruckCreateDto dto);

        public Task<bool> TruckStatusUpdateAsync(long id, TruckStatusDto dto);

        public Task<bool> UpdateAsync(long id, TruckUpdateDto updateDto);

        public Task<bool> UpdateLocationAsync(long id, LocationCreateDto dto);

        public Task<IEnumerable<TruckViewModel>> GetAllByIdAsync(long id, PaginationParams @paginationParams);

        public Task<IEnumerable<TruckViewModel>> GetLocationNameAsync(string locationName, PaginationParams @paginationParams);
    }
}
