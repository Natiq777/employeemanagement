using Application.Common.Exceptions;
using Application.Common.ResponseModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Department.Update
{
    public class UpdateDepartmentCommandHandler : BaseHandler,IRequestHandler<UpdateDepartmentCommand, BaseResponse>
    {
        public UpdateDepartmentCommandHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<BaseResponse> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var originalDepartment = await Context.Departments.FirstOrDefaultAsync(x => x.Id == request.Id, CancellationToken);

            if (originalDepartment==null)
            {
                throw new CustomException("Məlumat tapılmadı",System.Net.HttpStatusCode.NotFound);
            }  
            originalDepartment.Name = request.Name;

            await Context.SaveChangesAsync(CancellationToken);

            return new BaseResponse();
        } 
    }
}
