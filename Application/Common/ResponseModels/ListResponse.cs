namespace Application.Common.ResponseModels
{
    public class ListResponse<T> : BaseResponse
    {
        public ListResponse(PaginatedList<T> data)
        {

            Data = data;
        }

        public PaginatedList<T> Data { get; set; }
    }
}
