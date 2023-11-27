namespace Application.Common.ResponseModels
{
    public class GetResponse<T> : BaseResponse
    {
        public GetResponse()
        {

        }

        public GetResponse(T data)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
