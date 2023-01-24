using Caravan.DataAccess.DbContexts;
using Caravan.DataAccess.Interfaces;
using Caravan.DataAccess.Repositories.Common;
using Caravan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.DataAccess.Repositories
{
    public class TruckRepository : GenericRepository<Truck>, 
        ITruckRepository
    {
        public TruckRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
        public override async Task<Truck?> FindByIdAsync(long id)
        {
            var res = await _dbContext.Trucks.Include(x => x.User).Include(x => x.TruckLocation).FirstOrDefaultAsync(x => x.Id== id);
            if (res is null) return null; 
            return res;
        }

        public override IQueryable<Truck> GetAll()
        {
            var query = _dbContext.Trucks.Include(x => x.User).Include(x => x.TruckLocation).OrderByDescending(x => x.CreatedAt); 
            return query;
        }

        public override IQueryable<Truck> Where(Expression<Func<Truck, bool>> expression)
        {
            var query = _dbContext.Trucks.Include(x =>x.User).Include(x => x.TruckLocation).OrderByDescending(_ => _.CreatedAt);
            return query;
        }

    }
}
