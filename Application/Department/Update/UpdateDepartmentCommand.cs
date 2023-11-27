using Application.Common.ResponseModels;
using MediatR;
using Application.Common.Mappings;
using AutoMapper;
using Application.Common.Dto;

namespace Application.Department.Update
{
    public class UpdateDepartmentCommand : DepartmentDto,IRequest<BaseResponse>, IMapFrom
    {
        public int Id { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateDepartmentCommand, Domain.Entities.Department>();
        }
    }
}
