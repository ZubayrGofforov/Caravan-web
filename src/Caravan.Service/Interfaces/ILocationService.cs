using Caravan.Service.Dtos.Locations;

namespace Caravan.Service.Interfaces
{
    public interface ILocationService
    {
        public Task<(bool IsSuccessful, long Id)> CreateAsync(LocationCreateDto createDto);
        public Task<bool> UpdateAsync(long id, LocationCreateDto updateDto);
    }
}
