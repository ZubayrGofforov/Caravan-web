using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.Service.Common.Utils
{
    public class PagedList<T> :List<T>
    {
        public PaginationMetaData MetaData { get; set; } = default!;

        public PagedList(PaginationParams @params, int totalItems, List<T> items)
        {
            this.MetaData = new PaginationMetaData(totalItems, @params.PageNumber, @params.PageSize);
            AddRange(items);

        }

        public async Task<PagedList<T>> ToPagedListAsync(List<T> source, PaginationParams @params)
        {
            int totalItems = source.Count();
            var result =  source.Skip((@params.PageNumber-1)*@params.PageSize)
                .Take(@params.PageSize);
            return new PagedList<T>(@params, totalItems, result.ToList());
        }
    }
}
