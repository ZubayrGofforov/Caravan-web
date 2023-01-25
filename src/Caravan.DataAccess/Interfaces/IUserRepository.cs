using Caravan.DataAccess.Interfaces.Common;
using Caravan.Domain.Entities;

namespace Caravan.DataAccess.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User?> GetByEmailAsync(string email);
    }
}
