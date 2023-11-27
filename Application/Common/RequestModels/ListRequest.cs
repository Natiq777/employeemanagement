namespace Application.Common.RequestModels
{
    public class ListRequest
    {
        public List<Filters.CompareExpressionModel>? Filters { get; set; }
        public string? SortBy { get; set; }
        public string? SortByDirect { get; set; }
        public int PageNumber { get; set; }

        public int PageSize { get; set; }
    }
}
