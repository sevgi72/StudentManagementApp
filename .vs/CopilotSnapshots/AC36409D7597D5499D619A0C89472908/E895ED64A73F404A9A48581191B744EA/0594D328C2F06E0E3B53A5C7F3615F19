using StudentManagementApp.Dtos.Group;

namespace StudentManagementApp.Services.Interfaces
{
    public interface IGroupService
    {
        // Get all groups
        Task<IEnumerable<GroupReturnDto>> GetAllAsync();

        // Get group by id
        Task<GroupReturnDto?> GetByIdAsync(int id);

        // Create new group
        Task CreateAsync(GroupCreateDto dto);

        // Update group
        Task<bool> UpdateAsync(int id,GroupUpdateDto dto);

        // Delete group
        Task<bool> DeleteAsync(int id);
    }
}
