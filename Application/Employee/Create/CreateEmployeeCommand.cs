﻿using Application.Common.ResponseModels;
using MediatR;
using Application.Common.Mappings;
using AutoMapper;
using Application.Common.Dto;

namespace Application.Employee.Create
{
    public class CreateEmployeeCommand:EmployeeDto,IRequest<BaseResponse>, IMapFrom
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEmployeeCommand, Domain.Entities.Employee>();
        }
    }
}
