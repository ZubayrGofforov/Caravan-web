using Caravan.Domain.Entities;

namespace Caravan.Service.Interfaces.Security
{
    public interface IAuthManager
    {
        public string GenerateToken(User user);
        public string GenerateTokenAdmin(Administrator admin);
    }
}
