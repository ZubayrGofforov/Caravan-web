using Caravan.Domain.Common;
using System.Linq.Expressions;

namespace Caravan.DataAccess.Interfaces.Common
{
    public interface IRepository<T> where T : BaseEntity
    {
        public T Add(T entity);

        public void Delete(long id);

        public void Update(long id, T entity);

        public Task<T?> FindByIdAsync(long id);

        public Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        
        public void TrackingDeteched(T entity);
    }
}
