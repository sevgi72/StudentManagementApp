using FluentValidation;
using StudentManagementApp.Dtos.Group;

namespace StudentManagementApp.Validators.GroupValidator
{
    public class GroupUpdateDtoValidator:AbstractValidator<GroupUpdateDto>
    {
        public GroupUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name boş ola bilməz")
                .MinimumLength(3).WithMessage("Name minimum 3 simvol olmalıdır");
        }
    }
}
