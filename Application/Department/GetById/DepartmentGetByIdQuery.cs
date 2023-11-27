using Application.Common.Dto;
using Application.Common.RequestModels;
using Application.Common.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Department.GetById
{
    public class DepartmentGetByIdQuery : ListRequest,IRequest<GetResponse<DepartmentGetByIdDto>>
    {
        public int Id { get; set; }
    }
}
