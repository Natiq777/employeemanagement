using Application.Common.ResponseModels;
using MediatR;

namespace Application.Employee.Create
{
    public class CreateEmployeeCommandHandler : BaseHandler,IRequestHandler<CreateEmployeeCommand, BaseResponse>
    {
        public CreateEmployeeCommandHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<BaseResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = Mapper.Map<Domain.Entities.Employee>(request);
          
            employee.CreateDate= DateTime.Now;

            await Context.Employees.AddAsync(employee, CancellationToken);

            await Context.SaveChangesAsync(CancellationToken);

            return new BaseResponse();
        }
    }
}
