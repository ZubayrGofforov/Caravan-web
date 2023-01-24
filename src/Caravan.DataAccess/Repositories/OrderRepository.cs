using Caravan.DataAccess.DbContexts;
using Caravan.DataAccess.Interfaces;
using Caravan.DataAccess.Repositories.Common;
using Caravan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Caravan.DataAccess.Repositories
{
    public class OrderRepository : GenericRepository<Order>,
        IOrderRepository
    {
        public OrderRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public override async Task<Order?> FindByIdAsync(long id)
        {
            var res = await _dbContext.Orders.Include(x => x.User).Include(x => x.TakenLocation)
                .Include(x => x.DeliveryLocation).FirstOrDefaultAsync(x => x.Id == id);
            if (res is null)
                return null;
            return res;
        }

        public override IQueryable<Order> GetAll()
        {
            var query = _dbContext.Orders.Include(x => x.User).Include(x => x.TakenLocation).Include(x => x.DeliveryLocation);
            return query;
        }

        public override IQueryable<Order> Where(Expression<Func<Order, bool>> expression)
        {
            var query = _dbContext.Orders.Include(x => x.User).Include(x => x.TakenLocation).Include(x => x.DeliveryLocation);
            return query;
        }
    }
}
