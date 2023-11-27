using Application.Common.Exceptions;
using Application.Common.ResponseModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Employee.Update
{
    public class UpdateEmployeeCommandHandler : BaseHandler,IRequestHandler<UpdateEmployeeCommand, BaseResponse>
    {
        public UpdateEmployeeCommandHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<BaseResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var originalEmployee = await Context.Employees.FirstOrDefaultAsync(x => x.Id == request.Id, CancellationToken);

            if (originalEmployee==null)
            {
                throw new CustomException("Məlumat tapılmadı",System.Net.HttpStatusCode.NotFound);
            }  
            originalEmployee.Name = request.Name;
            originalEmployee.Surname = request.Surname;
            originalEmployee.BirthDate = request.BirthDate;
            originalEmployee.DepartmendId = request.DepartmendId;

            await Context.SaveChangesAsync(CancellationToken);

            return new BaseResponse();
        } 
    }
}
