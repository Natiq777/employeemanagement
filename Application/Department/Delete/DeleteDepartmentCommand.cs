using Application.Common.ResponseModels;
using MediatR;
namespace Application.Department.Delete
{
    public class DeleteDepartmentCommand : IRequest<BaseResponse>
    {
        public required int Id { get; set; }
    }
}
