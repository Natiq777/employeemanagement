using Application.Common.Exceptions;
using Application.Common.ResponseModels;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Department.Delete
{
    public class DeleteDepartmentCommandHandler : BaseHandler, IRequestHandler<DeleteDepartmentCommand, BaseResponse>
    {
        public DeleteDepartmentCommandHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        public async Task<BaseResponse> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var employee = await Context.Departments.FirstOrDefaultAsync(x => x.Id == request.Id, CancellationToken);

            if (employee == null)
            {
                throw new CustomException("Məlumat tapılmadı", System.Net.HttpStatusCode.NotFound);
            }

            Context.Departments.Remove(employee);

            await Context.SaveChangesAsync(CancellationToken);

            return new BaseResponse();
        }
    }
}
