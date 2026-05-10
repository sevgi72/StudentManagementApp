using Microsoft.AspNetCore.Mvc;
using StudentManagementApp.Dtos.Group;
using StudentManagementApp.Services.Interfaces;

namespace StudentManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        // GET: api/groups
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _groupService.GetAllAsync();
            return Ok(result);
        }

        // GET: api/groups/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _groupService.GetByIdAsync(id);

            if (result == null)
                return NotFound("Group not found");

            return Ok(result);
        }

        // POST: api/groups
        [HttpPost]
        public async Task<IActionResult> Create(GroupCreateDto dto)
        {
            await _groupService.CreateAsync(dto);
            return Ok("Group created successfully");
        }

        // PUT: api/groups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, GroupUpdateDto dto)
        {
            var result = await _groupService.UpdateAsync(id, dto);

            if (!result)
                return NotFound("Group not found");

            return Ok("Group updated successfully");
        }

        // DELETE: api/groups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _groupService.DeleteAsync(id);

            if (!result)
                return NotFound("Group not found");

            return Ok("Group deleted successfully");
        }
    }
}