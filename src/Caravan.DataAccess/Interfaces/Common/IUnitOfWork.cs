using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.DataAccess.Interfaces.Common
{
    public interface IUnitOfWork
    {
        public IAdministratorRepository Administrators { get; }

        public IOrderRepository Orders { get; }

        public ITruckRepository Trucks { get; }

        public IUserRepository Users { get; }
        public ILocationRepository Locations { get; }

        public Task<int> SaveChangesAsync();
    }
}
