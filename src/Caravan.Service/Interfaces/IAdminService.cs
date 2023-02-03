using Caravan.Service.Common.Utils;
using Caravan.Service.Dtos.Admins;
using Caravan.Service.ViewModels;

namespace Caravan.Service.Interfaces
{
    public interface IAdminService
    {
        public Task<bool> DeleteAsync(long id);
        public Task<bool> UpdateAsync(long id, AdminCreateDto dto);
        public Task<PagedList<AdminViewModel>> GetAllAsync(PaginationParams @params);
        public Task<AdminViewModel> GetByIdAsync(long id);
    }
}
