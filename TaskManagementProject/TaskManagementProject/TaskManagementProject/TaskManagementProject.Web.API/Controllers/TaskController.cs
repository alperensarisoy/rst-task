using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagementProject.Domain.Dto;
using TaskManagementProject.Domain.Entities;
using TaskManagementProject.Service.Interfaces;
using TaskManagementProject.Service.Services;

namespace TaskManagementProject.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService<t_TaskDto, t_Task> _taskService;


        public TaskController(ITaskService<t_TaskDto, t_Task> taskService)
        {
            this._taskService = taskService; 
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var tasks = await _taskService.GetAllAsync();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            try
            {
                var task = await _taskService.GetByIdAsync(id);
                return Ok(task);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPost("AddTask")]
        public async Task<IActionResult> AddTask([FromBody] t_TaskDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("Task data cannot be null.");
                }

                var createdTask = await _taskService.AddAsync(dto);
                return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [Authorize]
        [HttpPut("updateTask")]
        public async Task<IActionResult> UpdateTask( [FromBody] t_TaskDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("User Data Cannot be null");
                }

                var updatedTask = await _taskService.UpdateAsync(dto);
                return Ok(updatedTask);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [Authorize]
        [HttpDelete("DeleteTask")]
        public async Task<IActionResult> DeleteTask([FromBody] t_TaskDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("Task data cannot be null.");
                }

                var result = await _taskService.DeleteByAsync(dto);

                if (result)
                {
                    return Ok("Task deleted successfully.");
                }

                return BadRequest("Failed to delete the task.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }



    }
}
