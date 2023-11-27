using Application.Common.Exceptions;
using Application.Common.ResponseModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Department.GetById
{
    public class DepartmentGetByIdQueryHandler : BaseHandler, IRequestHandler<DepartmentGetByIdQuery, GetResponse<DepartmentGetByIdDto>>
    {
        public DepartmentGetByIdQueryHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        public async Task<GetResponse<DepartmentGetByIdDto>> Handle(DepartmentGetByIdQuery request, CancellationToken cancellationToken)
        {

            var query = await Context.Departments
             
                .FirstOrDefaultAsync(x => x.Id == request.Id,CancellationToken);

            if (query == null)
            {
                throw new CustomException("Məlumat tapılmadı", System.Net.HttpStatusCode.NotFound);
            }

            var result = new DepartmentGetByIdDto
            {
                Id = request.Id,
                Name = query.Name,
                CreateDate = query.CreateDate,
            };
            
            return new GetResponse<DepartmentGetByIdDto>(result);
        }
    }
}
