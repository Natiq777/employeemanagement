﻿using Application.Common.ResponseModels;
using MediatR;
namespace Application.Employee.Delete
{
    public class DeleteEmployeeCommand : IRequest<BaseResponse>
    {
        public required int Id { get; set; }
    }
}
