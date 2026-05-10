using FluentValidation;
using StudentManagementApp.Dtos.Student;

namespace StudentManagementApp.Validators.StudentValidator
{
    public class StudentUpdateDtoValidator:AbstractValidator<StudentUpdateDto>
    {
        public StudentUpdateDtoValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("FullName boş ola bilməz")
                .MinimumLength(3).WithMessage("FullName minimum 3 simvol olmalıdır");
            RuleFor(x => x.Age)
                .InclusiveBetween(16, 60).WithMessage("Age 16-60 aralığında olmalıdır");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş ola bilməz")
                .EmailAddress().WithMessage("Email düzgün formatda deyil");
        }
    }
}
