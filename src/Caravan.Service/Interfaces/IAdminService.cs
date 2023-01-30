using Caravan.Domain.Entities;
using Caravan.Service.Common.Utils;
using Caravan.Service.Dtos.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Service.Interfaces
{
    public interface IAdminService
    {
        public Task<bool> DeleteAsync(long id);
        public Task<bool> UpdateAsync(long id, AdminCreateDto dto);
        public Task<IEnumerable<AdminViewModel>> GetAllAsync(PaginationParams @params);
        public Task<AdminViewModel> GetByIdAsync(long id);
    }
}
