using Application.Common.RequestModels;
using Application.Common.ResponseModels;
using Application.Employee.GetById;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employee.Get
{
    public class EmployeeAllQuery:ListRequest,IRequest<ListResponse<EmployeeGetByIdDto>>
    {
    }
}
