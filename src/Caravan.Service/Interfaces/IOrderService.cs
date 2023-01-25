using Caravan.Service.Common.Utils;
using Caravan.Service.Dtos.Orders;
using Caravan.Service.ViewModels;

namespace Caravan.Service.Interfaces
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderViewModel>> GetAllAsync(PaginationParams @paginationParams);

        public Task<OrderViewModel> GetAsync(long id);

        public Task<bool> UpdateAsync(long id, OrderUpdateDto updateDto);

        public Task<bool> DeleteAsync(long id);

        public Task<bool> CreateAsync(OrderCreateDto createDto);

        public Task<bool> UpdateStatusAsync(long id, OrderStatusDto dto);

        public Task<IEnumerable<OrderViewModel>> GetAllByIdAsync(long id, PaginationParams @paginationParams);

        public Task<IEnumerable<OrderViewModel>> GetLocationNameAsync(string locationName, PaginationParams @paginationParams);
    }
}
