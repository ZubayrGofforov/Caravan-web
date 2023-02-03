using Microsoft.EntityFrameworkCore;

namespace Caravan.Service.Common.Utils;
public class PagedList<T> : List<T>
{
    public PaginationMetaData MetaData { get; set; } = default!;

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