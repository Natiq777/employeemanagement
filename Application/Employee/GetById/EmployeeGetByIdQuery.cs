using Application.Common.Dto;
using Application.Common.RequestModels;
using Application.Common.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Employee.GetById
{
    public class EmployeeGetByIdQuery:ListRequest,IRequest<GetResponse<EmployeeGetByIdDto>>
    {
        public int Id { get; set; }
    }
}
