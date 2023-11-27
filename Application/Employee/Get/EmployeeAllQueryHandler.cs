using Application.Common.Exceptions;
using Application.Common.Mappings;
using Application.Common.ResponseModels;
using Application.Employee.GetById;
using Application.Filters;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employee.Get
{
    public class EmployeeAllQueryHandler :BaseHandler,IRequestHandler<EmployeeAllQuery,ListResponse<EmployeeGetByIdDto>>
    {
        public EmployeeAllQueryHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        public async Task<ListResponse<EmployeeGetByIdDto>> Handle(EmployeeAllQuery request, CancellationToken cancellationToken)
        {

            var query = Context.Employees
                .Include(x => x.Department)
                .Select(x => new EmployeeGetByIdDto
                {
                    BirthDate = x.BirthDate,
                    DepartmendId = x.DepartmendId,
                    Department = x.Department.Name,
                    Name = x.Name,
                    Surname = x.Surname,
                }).AddWhereExpressionsToQuery(request.Filters).CustomOrderBy(request.SortBy,request.SortByDirect);             

            if (query == null)
            {
                throw new CustomException("Məlumat tapılmadı", System.Net.HttpStatusCode.NotFound);
            } 

            return (await query.PaginatedListAsync(request.PageNumber,request.PageSize)).ToListResponse();
        }
    }
}
