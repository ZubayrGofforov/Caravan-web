namespace Caravan.Service.Interfaces.Common
{
    public interface IPaginatorService
    {
        public Task<IList<T>> ToPagedAsync<T>(IList<T> items, int pageNumber, int pageSize);
    }
}
