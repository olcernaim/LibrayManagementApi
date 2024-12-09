using LibrayManagementApi.Common.Model;
using LibrayManagementApi.DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrayManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IGenericRepository<AUTHOR> _authorService;
        public AuthorController( IGenericRepository<AUTHOR> authorService)
        {
            _authorService = authorService;
        }

        [HttpGet(Name = "GetAuthors")]
        public async Task<IActionResult> GetAuthors()
        {
            var authorList = await _authorService.GetAllAsync();
            return Ok(authorList.OrderBy(p => p.ID));
        }
    }
}
