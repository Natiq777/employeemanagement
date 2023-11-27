using FluentValidation;

namespace Application.Employee.Create
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage(CreateEmployeeCommandValidationMessage.NAME);
            RuleFor(x => x.Surname)
               .NotEmpty()
               .WithMessage(CreateEmployeeCommandValidationMessage.NAME);
            RuleFor(x => x.DepartmendId)
               .NotEmpty()
               .WithMessage(CreateEmployeeCommandValidationMessage.DEPARTAMENT);
            RuleFor(x => x.BirthDate)
               .NotEmpty()
               .WithMessage(CreateEmployeeCommandValidationMessage.BIRTHDATE);

        }
    }
}
