using Caravan.DataAccess.DbContexts;
using Caravan.DataAccess.Interfaces;
using Caravan.DataAccess.Repositories.Common;
using Caravan.Domain.Common;

namespace Caravan.DataAccess.Repositories
{
    public class LocationRepository : GenericRepository<Location>,
        ILocationRepository
    {
        public LocationRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
