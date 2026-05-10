// IStudentRepository.cs

using StudentManagementApp.Models;

namespace StudentManagementApp.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();

        Task<Student?> GetByIdAsync(int id);

        Task AddAsync(Student student);

        void Update(Student student);

        void Delete(Student student);

        Task<bool> ExistsByEmailAsync(string email);

        Task SaveChangesAsync();
    }
}