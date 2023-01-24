using Caravan.Service.Common.Utils;
using Caravan.Service.Dtos.Users;
using Caravan.Service.ViewModels;

namespace Caravan.Service.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<UserViewModel>> GetAllAysnc(PaginationParams @params);
        public Task<UserViewModel> GetAsync(long id);
        public Task<bool> UpdateAsync(long id, UserUpdateDto entity);
        public Task<bool> DeleteAsync(long id);

        public Task<UserViewModel> GetEmailAsync(string email);
    }
}
