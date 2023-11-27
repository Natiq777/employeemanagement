using Application.Common.ResponseModels;
using MediatR;

namespace Application.Department.Create
{
    public class CreateDepartmentCommandHandler : BaseHandler,IRequestHandler<CreateDepartmentCommand, BaseResponse>
    {
        public CreateDepartmentCommandHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<BaseResponse> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = Mapper.Map<Domain.Entities.Department>(request);
          
            department.CreateDate= DateTime.Now;

            await Context.Departments.AddAsync(department, CancellationToken);

            await Context.SaveChangesAsync(CancellationToken);

            return new BaseResponse();
        }
    }
}
