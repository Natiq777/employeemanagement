using Application.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class PaginatedList<T>
    {
        public PaginatedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            Items = items;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            FirstItem = ((PageNumber - 1) * PageSize) + 1;
            LastItem = FirstItem + Items.Count - 1;
            HasPreviousPage = PageNumber > 1;
            HasNextPage = PageNumber < TotalPages;
        }

        public List<T> Items { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }
        public int FirstItem { get; }
        public int LastItem { get; }
        public bool HasPreviousPage { get; }
        public bool HasNextPage { get; }

        private const int DefaultPageNumber = 1;
        private const int DefaultPageSize = 10;
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source,int pageNumber, int pageSize)
        {
           

            var count = await source.CountAsync();
            if (pageNumber < 1)
                pageNumber = DefaultPageNumber;
            if (pageSize < 1)
                pageSize = DefaultPageSize;

            var numberToSkip = GetSkipNumber(count, ref pageNumber, pageSize);
            var items = await source.Skip(numberToSkip).Take(pageSize).ToListAsync();

            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }

        private static int GetSkipNumber(int count, ref int pageNumber, int pageSize)
        {
            var numberToSkip = (pageNumber - 1) * pageSize;
            while (numberToSkip > count)
            {
                numberToSkip -= pageSize;
                pageNumber--;
            }

            return numberToSkip;
        }
    }
}
