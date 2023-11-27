using Application.Common.RequestModels;
using Application.Common.ResponseModels;
using Application.Department.GetById; 
using MediatR; 

namespace Application.Department.Get
{
    public class DepartmentAllQuery : ListRequest,IRequest<ListResponse<DepartmentGetByIdDto>>
    {
    }
}
