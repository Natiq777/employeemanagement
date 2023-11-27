using Application.Department.Create;
using FluentValidation;

namespace Application.Department.Update
{
    public class UpdateDepartmentCommandValidator : AbstractValidator<UpdateDepartmentCommand>
    {
        public UpdateDepartmentCommandValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .WithMessage(UpdateDepartmentCommandValidationMessage.ID);
            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage(UpdateDepartmentCommandValidationMessage.NAME); 

        }
    }
}
