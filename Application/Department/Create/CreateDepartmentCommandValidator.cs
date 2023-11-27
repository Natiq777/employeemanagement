using Application.Employee.Create;
using FluentValidation;

namespace Application.Department.Create
{
    public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentCommandValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage(CreateDepartmentCommandValidationMessage.NAME); 

        }
    }
}
