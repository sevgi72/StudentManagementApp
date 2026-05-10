using FluentValidation;
using StudentManagementApp.Dtos.Group;

namespace StudentManagementApp.Validators.GroupValidator
{
    public class GroupCreateDtoValidator:AbstractValidator<GroupCreateDto>
    {
        public GroupCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name boş ola bilməz")
                .MinimumLength(3).WithMessage("Name minimum 3 simvol olmalıdır");
            
        }
    }
}
