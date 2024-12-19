using LibrayManagementApi.Common.Model;
using LibrayManagementApi.DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrayManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGenericRepository<USERS> _userService;

        public UserController(IGenericRepository<USERS> userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var userList = await _userService.GetAllAsync();

            return Ok(userList.OrderBy(p => p.ID));
        }
        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            return Ok(user);
        }
        [HttpGet("GetUserByName/{name}")]
        public async Task<IActionResult> GetUserByName(string name)
        {
            var user = await _userService.GetWhere(p => p.USERNAME == name);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> InsertUser(USERS user)
        {
            var status = await _userService.InsertAsync(user);

            return Ok(status);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUSer(int id)
        {
            var status = await _userService.DeleteAsync(id);

            return Ok(status);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser(USERS user)
        {
            var status = await _userService.UpdateAsync(user);

            return Ok(status);
        }
    }
}
