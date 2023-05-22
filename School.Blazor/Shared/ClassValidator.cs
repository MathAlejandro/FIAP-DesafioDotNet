using FluentValidation;
using School.Blazor.DTO;

namespace School.Blazor.Shared
{
    public class ClassValidator : AbstractValidator<ClassDTO>
    {
        public ClassValidator()
        {
            //https://stackoverflow.com/questions/63864594/how-can-i-create-strong-passwords-with-fluentvalidation
            RuleFor(cl => cl.Year)
                .GreaterThan(DateTime.Now.Year).WithMessage("Não é permitido criar Turmas com datas anteriores da atual.");


        }
    }
}
