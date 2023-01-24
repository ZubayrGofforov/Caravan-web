using Caravan.DataAccess.DbContexts;
using Caravan.DataAccess.Interfaces;
using Caravan.DataAccess.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.DataAccess.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        public IAdministratorRepository Administrators { get; }

        public IOrderRepository Orders { get; }

        public ITruckRepository Trucks { get; }

        public IUserRepository Users { get; }
        public ILocationRepository Locations { get; }
        public UnitOfWork(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
            
            Administrators = new AdministratorRepository(appDbContext);

            Orders = new OrderRepository(appDbContext);

            Trucks = new TruckRepository(appDbContext);

            Users = new UserRepository(appDbContext);

            Locations = new LocationRepository(appDbContext);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _appDbContext.SaveChangesAsync();
        }
    }
}
