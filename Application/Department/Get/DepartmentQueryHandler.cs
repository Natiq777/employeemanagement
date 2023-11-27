using Application.Common.Exceptions;
using Application.Common.Mappings;
using Application.Common.ResponseModels;
using Application.Department.GetById;
using Application.Filters;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Department.Get
{
    public class DepartmentQueryHandler : BaseHandler,IRequestHandler<DepartmentAllQuery,ListResponse<DepartmentGetByIdDto>>
    {
        public DepartmentQueryHandler(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<ListResponse<DepartmentGetByIdDto>> Handle(DepartmentAllQuery request, CancellationToken cancellationToken)
        {

            var query = Context.Departments 
                .Select(x => new DepartmentGetByIdDto
                { 
                    Id=x.Id,
                    Name = x.Name,
                    CreateDate = x.CreateDate,
                }).AddWhereExpressionsToQuery(request.Filters).CustomOrderBy(request.SortBy, request.SortByDirect);             

            if (query == null)
            {
                throw new CustomException("Məlumat tapılmadı", System.Net.HttpStatusCode.NotFound);
            } 

            return (await query.PaginatedListAsync(request.PageNumber,request.PageSize)).ToListResponse();
        }
    }
}
