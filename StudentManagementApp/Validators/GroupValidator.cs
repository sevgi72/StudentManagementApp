using StudentManagementApp.Dtos.Group;
using StudentManagementApp.Repositories.Interfaces;

namespace StudentManagementApp.Services.Validators
{
    public class GroupValidator
    {
        private readonly IGroupRepository _groupRepository;

        public GroupValidator(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task ValidateCreateAsync(GroupCreateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new Exception("Group adı boş ola bilməz");

            if (await _groupRepository.ExistsByNameAsync(dto.Name))
                throw new Exception("Bu group adı artıq mövcuddur");
        }

        public async Task ValidateUpdateAsync(int id, GroupUpdateDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new Exception("Group adı boş ola bilməz");

            var exists = await _groupRepository.ExistsByNameAsync(dto.Name);

            if (exists)
                throw new Exception("Bu group adı artıq mövcuddur");
        }
    }
}