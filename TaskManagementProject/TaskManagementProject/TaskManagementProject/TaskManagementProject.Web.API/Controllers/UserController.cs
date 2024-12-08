using Microsoft.AspNetCore.Mvc;
using TaskManagementProject.Domain.Dto;
using TaskManagementProject.Domain.Entities;
using TaskManagementProject.Service.Interfaces;



namespace TaskManagementProject.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService<t_UserDto, t_User> _userService;

        public UserController(IUserService<t_UserDto , t_User> userService)
        {
            _userService = userService; 
        }



        // Normal Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userService.ValidateUserAsync(loginDto.UserName, loginDto.Password);

            if (user == null)
                return Unauthorized("Invalid credentials.");

            var token = _userService.GenerateJwtToken(user);

            return Ok(new { Token = token });
        }



        [HttpGet("GetAll")]
        public async Task<ICollection<t_UserDto>> GetAll()
        {
            var result = await _userService.GetAllAsync();
            return result;
        }


        [HttpPost("AddUser")]
        public async Task<IActionResult> Add([FromBody] t_UserDto dto)
        {
            if (dto == null)
            {
                return BadRequest("User data Cannot be null.");
            }
            var result = await _userService.AddAsync(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetByIdAsync(id);
                return Ok(user);
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

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody] t_UserDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("User data cannot be null.");
                }

                var result = await _userService.DeleteByAsync(dto);

                if (result)
                {
                    return Ok("User deleted successfully.");
                }

                return BadRequest("Failed to delete the user.");
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




        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] t_UserDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("User Data Cannot be null");
                }
                var updatedUser = await _userService.UpdateAsync(dto);

                // Başarıyla güncellendiyse 200 OK döner
                return Ok(updatedUser);
            }
            catch (ArgumentNullException ex)
            {
                // Kullanıcı bulunamazsa 404 Not Found döner
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                // Beklenmeyen durumlar için 500 Internal Server Error döner
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }

        }


    }
}
