// IGroupRepository.cs

using StudentManagementApp.Models;

namespace StudentManagementApp.Repositories.Interfaces
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetAllAsync();

        Task<Group?> GetByIdAsync(int id);

        Task AddAsync(Group group);

        void Update(Group group);

        void Delete(Group group);

        Task<bool> ExistsByNameAsync(string name);

        Task<bool> ExistsByIdAsync(int id);

        Task SaveChangesAsync();
    }
}