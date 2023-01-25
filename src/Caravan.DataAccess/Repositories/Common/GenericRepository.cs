using Caravan.DataAccess.DbContexts;
using Caravan.DataAccess.Interfaces.Common;
using Caravan.Domain.Common;
using System.Linq.Expressions;

namespace Caravan.DataAccess.Repositories.Common
{
    public class GenericRepository<T> : BaseRepository<T>, IGenericRepository<T>
        where T : BaseEntity
    {
        public GenericRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {

        }
        public virtual IQueryable<T> GetAll() => _dbSet;

        public virtual IQueryable<T> Where(Expression<Func<T, bool>> expression)
            => _dbSet.Where(expression);
    }
}
