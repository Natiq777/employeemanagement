﻿using Application.Common.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mappings
{
    public static class MappingExtensions
    {
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize)
            => PaginatedList<TDestination>.CreateAsync(queryable ,pageNumber, pageSize);

        public static ListResponse<TDestination> ToListResponse<TDestination>(this PaginatedList<TDestination> paginatedList) => new ListResponse<TDestination>(paginatedList);
    }
}
