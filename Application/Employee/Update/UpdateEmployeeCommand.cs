using Application.Common.ResponseModels;
using MediatR;
using Application.Common.Mappings;
using AutoMapper;
using Application.Common.Dto;

namespace Application.Employee.Update
{
    public class UpdateEmployeeCommand : EmployeeDto,IRequest<BaseResponse>, IMapFrom
    {
        public int Id { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateEmployeeCommand, Domain.Entities.Employee>();
        }
    }
}
