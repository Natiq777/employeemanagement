using Application.Common.Exceptions;
using Application.Common.ResponseModels; 
using MediatR;
using Microsoft.EntityFrameworkCore; 
namespace Application.Employee.Delete
{
    public class DeleteEmployeeCommandHandler : BaseHandler, IRequestHandler<DeleteEmployeeCommand, BaseResponse>
    {
        public DeleteEmployeeCommandHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        public async Task<BaseResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await Context.Employees.FirstOrDefaultAsync(x => x.Id == request.Id, CancellationToken);

            if (employee == null)
            {
                throw new CustomException("Məlumat tapılmadı", System.Net.HttpStatusCode.NotFound);
            }

            Context.Employees.Remove(employee);

            await Context.SaveChangesAsync(CancellationToken);

            return new BaseResponse();
        }
    }
}
