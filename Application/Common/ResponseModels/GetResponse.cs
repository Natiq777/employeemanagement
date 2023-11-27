using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
