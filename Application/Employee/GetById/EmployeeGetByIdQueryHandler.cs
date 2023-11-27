using Application.Common.Exceptions;
using Application.Common.ResponseModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employee.GetById
{
    public class EmployeeGetByIdQueryHandler : BaseHandler, IRequestHandler<EmployeeGetByIdQuery, GetResponse<EmployeeGetByIdDto>>
    {
        public EmployeeGetByIdQueryHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        public async Task<GetResponse<EmployeeGetByIdDto>> Handle(EmployeeGetByIdQuery request, CancellationToken cancellationToken)
        {

            var query = await Context.Employees
                .Include(x=>x.Department)
                .FirstOrDefaultAsync(x => x.Id == request.Id,CancellationToken);

            if (query == null)
            {
                throw new CustomException("Məlumat tapılmadı", System.Net.HttpStatusCode.NotFound);
            }

            var result = new EmployeeGetByIdDto
            {
                BirthDate = query.BirthDate,
                DepartmendId = query.DepartmendId,
                Department = query.Department.Name,
                Name = query.Name,
                Surname = query.Surname,
            };
            
            return new GetResponse<EmployeeGetByIdDto>(result);
        }
    }
}
