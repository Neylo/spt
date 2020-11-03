using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPTest.UserReceiverService.Api.Common
{
    public class PagedList<T>
    {
        public PagedList(int pageIndex, int pageCount,int totalPages, List<T> items)
        {
            TotalPages = totalPages;
            PageIndex = pageIndex;
            PageCount = pageCount;
            Items = items;
        }

        public int TotalPages { get; private set; }
        public int PageIndex { get; private set; }
        public int PageCount { get; private set; }
        public List<T> Items { get; private set; }
    }
}
