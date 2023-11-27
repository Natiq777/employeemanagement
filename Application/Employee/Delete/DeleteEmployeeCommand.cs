using Application.Common.ResponseModels;
using MediatR;
namespace Application.Delete.Create
{
    public class DeleteEmployeeCommand : IRequest<BaseResponse>
    {
        public required int Id { get; set; }
    }
}
