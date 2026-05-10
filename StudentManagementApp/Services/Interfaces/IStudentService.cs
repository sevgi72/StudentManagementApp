// IStudentService.cs

using StudentManagementApp.Dtos.Student;
namespace StudentManagementApp.Services.Interfaces
{
    public interface IStudentService
    {
        // Get all students with pagination + search
        Task<IEnumerable<StudentReturnDto>> GetAllAsync(
            int page,
            int pageSize,
            string? search);

        // Get student by id
        Task<StudentReturnDto?> GetByIdAsync(int id);

        // Create new student
        Task CreateAsync(StudentCreateDto dto);

        // Update student
        Task<bool> UpdateAsync(int id, StudentUpdateDto dto);

        // Delete student
        Task<bool> DeleteAsync(int id);
    }
}