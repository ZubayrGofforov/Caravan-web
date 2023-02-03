namespace Caravan.Service.Common.Utils
{
    public class PaginationMetaData
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }

        public PaginationMetaData(int currentPage, int pageSize, int totalItems)
        {
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling((double)(totalItems / pageSize));
            HasNext = TotalPages > currentPage;
            HasPrevious = currentPage > 1;
            PageSize = pageSize;
            TotalItems = totalItems;
        }
    }
}
