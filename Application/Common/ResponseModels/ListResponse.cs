using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
