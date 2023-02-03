//namespace Caravan.Service.Common.Utils;
//public class PagedList<T> :List<T>
//{
//    public PaginationMetaData MetaData { get; set; } = default!;

//    public PagedList(PaginationParams @params, int totalItems, List<T> items)
//    {
//        this.MetaData = new PaginationMetaData(totalItems, @params.PageNumber, @params.PageSize);
//        AddRange(items);

<<<<<<< HEAD
//    }

//    public async Task<PagedList<T>> ToPagedListAsync(List<T> source, PaginationParams @params)
//    {
//        int totalItems = source.Count();
//        var result =  source.Skip((@params.PageNumber-1)*@params.PageSize)
//            .Take(@params.PageSize);
//        return new PagedList<T>(@params, totalItems, result.ToList());
//    }
//}
=======
        public PagedList(List<T> items,PaginationParams @params, int totalItems)
        {
            this.MetaData = new PaginationMetaData(@params.PageNumber, @params.PageSize, totalItems);
            AddRange(items);

        }

        public static async Task<PagedList<T>> ToPagedListAsync(IQueryable<T> source, PaginationParams @params)
        {
            int totalItems = source.Count();
            var result = await source.Skip((@params.PageNumber-1)*@params.PageSize)
                .Take(@params.PageSize).ToListAsync();
            return new PagedList<T>(result ,@params, totalItems);
        }
    }
}
>>>>>>> 5c1bc51 (Add Pagination)
