using StudentManagementApp.Dtos.Student;
using StudentManagementApp.Repositories.Interfaces;

namespace StudentManagementApp.Services.Validators
{
    public class StudentValidator
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IGroupRepository _groupRepository;

        public StudentValidator(
            IStudentRepository studentRepository,
            IGroupRepository groupRepository)
        {
            _studentRepository = studentRepository;
            _groupRepository = groupRepository;
        }

        public async Task ValidateCreateAsync(StudentCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FullName) || dto.FullName.Length < 3)
                throw new Exception("FullName minimum 3 simvol olmalıdır");

            if (dto.Age < 16 || dto.Age > 60)
                throw new Exception("Age 16-60 aralığında olmalıdır");

            if (string.IsNullOrWhiteSpace(dto.Email))
                throw new Exception("Email boş ola bilməz");

            if (!dto.Email.Contains("@"))
                throw new Exception("Email düzgün formatda deyil");

            if (await _studentRepository.ExistsByEmailAsync(dto.Email))
                throw new Exception("Bu email artıq mövcuddur");

            if (!await _groupRepository.ExistsByIdAsync(dto.GroupId))
                throw new Exception("Group mövcud deyil");
        }

        public async Task ValidateUpdateAsync(int id, StudentUpdateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.FullName) || dto.FullName.Length < 3)
                throw new Exception("FullName minimum 3 simvol olmalıdır");

            if (dto.Age < 16 || dto.Age > 60)
                throw new Exception("Age 16-60 aralığında olmalıdır");

            if (string.IsNullOrWhiteSpace(dto.Email))
                throw new Exception("Email boş ola bilməz");

            if (!dto.Email.Contains("@"))
                throw new Exception("Email düzgün formatda deyil");

            if (!await _groupRepository.ExistsByIdAsync(dto.GroupId))
                throw new Exception("Group mövcud deyil");
        }
    }
}