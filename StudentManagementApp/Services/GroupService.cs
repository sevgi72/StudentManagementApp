using AutoMapper;
using FluentValidation;
using StudentManagementApp.Dtos.Group;
using StudentManagementApp.Models;
using StudentManagementApp.Repositories.Interfaces;
using StudentManagementApp.Services.Interfaces;
using StudentManagementApp.Services.Validators;

namespace StudentManagementApp.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IValidator<GroupCreateDto> _createValidator;
        private readonly IValidator<GroupUpdateDto> _updateValidator;
        private readonly IMapper _mapper;

        public GroupService(
            IGroupRepository groupRepository,
            IValidator<GroupCreateDto> createValidator,
            IValidator<GroupUpdateDto> updateValidator,
            IMapper mapper)
        {
            _groupRepository = groupRepository;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _mapper = mapper;
        }

        // GET ALL
        public async Task<IEnumerable<GroupReturnDto>> GetAllAsync()
        {
            var groups = await _groupRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<GroupReturnDto>>(groups);
        }

        // GET BY ID
        public async Task<GroupReturnDto?> GetByIdAsync(int id)
        {
            var group = await _groupRepository.GetByIdAsync(id);

            if (group == null) return null;

            return _mapper.Map<GroupReturnDto>(group);
        }

        // CREATE
        public async Task CreateAsync(GroupCreateDto dto)
        {
            await _createValidator.ValidateAndThrowAsync(dto);

            var group = _mapper.Map<Group>(dto);

            await _groupRepository.AddAsync(group);
            await _groupRepository.SaveChangesAsync();
        }

        // UPDATE
        public async Task<bool> UpdateAsync(int id, GroupUpdateDto dto)
        {
            var group = await _groupRepository.GetByIdAsync(id);

            if (group == null)
                return false;

            await _updateValidator.ValidateAndThrowAsync(dto);

            _mapper.Map(dto, group);

            _groupRepository.Update(group);
            await _groupRepository.SaveChangesAsync();

            return true;
        }

        // DELETE
        public async Task<bool> DeleteAsync(int id)
        {
            var group = await _groupRepository.GetByIdAsync(id);

            if (group == null)
                return false;

            _groupRepository.Delete(group);
            await _groupRepository.SaveChangesAsync();

            return true;
        }
    }
}