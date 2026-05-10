using Microsoft.AspNetCore.Mvc;
using StudentManagementApp.Dtos.Student;
using StudentManagementApp.Services.Interfaces;

namespace StudentManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/students?page=1&pageSize=5&search=ali
        [HttpGet]
        public async Task<IActionResult> GetAll(
            int page = 1,
            int pageSize = 5,
            string? search = null)
        {
            var result = await _studentService.GetAllAsync(page, pageSize, search);
            return Ok(result);
        }

        // GET: api/students/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _studentService.GetByIdAsync(id);

            if (result == null)
                return NotFound("Student not found");

            return Ok(result);
        }

        // POST: api/students
        [HttpPost]
        public async Task<IActionResult> Create(StudentCreateDto dto)
        {
            await _studentService.CreateAsync(dto);
            return Ok("Student created successfully");
        }

        // PUT: api/students/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentUpdateDto dto)
        {
            var result = await _studentService.UpdateAsync(id, dto);

            if (!result)
                return NotFound("Student not found");

            return Ok("Student updated successfully");
        }

        // DELETE: api/students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _studentService.DeleteAsync(id);

            if (!result)
                return NotFound("Student not found");

            return Ok("Student deleted successfully");
        }
    }
}