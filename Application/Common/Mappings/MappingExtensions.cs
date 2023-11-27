using Application.Common.ResponseModels;

namespace Application.Common.Mappings
{
    public static class MappingExtensions
    {
        public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize)
            => PaginatedList<TDestination>.CreateAsync(queryable ,pageNumber, pageSize);

        public static ListResponse<TDestination> ToListResponse<TDestination>(this PaginatedList<TDestination> paginatedList) => new ListResponse<TDestination>(paginatedList);
    }
}
