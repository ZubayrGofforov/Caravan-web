using Caravan.DataAccess.DbContexts;
using Caravan.DataAccess.Interfaces;
using Caravan.DataAccess.Repositories.Common;
using Caravan.Domain.Entities;

namespace Caravan.DataAccess.Repositories
{
    public class AdministratorRepository : GenericRepository<Administrator>,
        IAdministratorRepository
    {
        public AdministratorRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
