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
