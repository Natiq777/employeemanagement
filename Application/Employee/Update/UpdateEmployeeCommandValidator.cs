using Application.Employee.Create;
using FluentValidation;

namespace Application.Employee.Update
{
    public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
    {
        public UpdateEmployeeCommandValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .WithMessage(UpdateEmployeeCommandValidationMessage.ID);
            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage(UpdateEmployeeCommandValidationMessage.NAME);
            RuleFor(x => x.Surname)
               .NotEmpty()
               .WithMessage(UpdateEmployeeCommandValidationMessage.NAME);
            RuleFor(x => x.DepartmendId)
               .NotEmpty()
               .WithMessage(UpdateEmployeeCommandValidationMessage.DEPARTAMENT);
            RuleFor(x => x.BirthDate)
               .NotEmpty()
               .WithMessage(UpdateEmployeeCommandValidationMessage.BIRTHDATE);

        }
    }
}
