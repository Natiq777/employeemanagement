using Application.Common.ResponseModels;
using MediatR;
using Application.Common.Mappings;
using AutoMapper;
using Application.Common.Dto;

namespace Application.Department.Create
{
    public class CreateDepartmentCommand : DepartmentDto,IRequest<BaseResponse>, IMapFrom
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDepartmentCommand, Domain.Entities.Department>();
        }
    }
}
