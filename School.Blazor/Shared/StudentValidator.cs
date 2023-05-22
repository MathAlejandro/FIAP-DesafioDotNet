using FluentValidation;
using School.Blazor.DTO;

namespace School.Blazor.Shared
{
    public class StudentValidator: AbstractValidator<StudentDTO>
    {
        public StudentValidator() {
            //https://stackoverflow.com/questions/63864594/how-can-i-create-strong-passwords-with-fluentvalidation
            RuleFor(student => student.Password)
                .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                    .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                    .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.")
                    .Matches(@"[\!\?\*\.]+").WithMessage("Your password must contain at least one (!? *.).");


        }
    }
}
