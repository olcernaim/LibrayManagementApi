using LibrayManagementApi.Common.Model;
using LibrayManagementApi.DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrayManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IGenericRepository<CATEGORY> _categoryService;
        public CategoryController(IGenericRepository<CATEGORY> categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet(Name = "GetAllCategory")]
        public async Task<IActionResult> GetAllCategory()
        {
            var categoryList = await _categoryService.GetAllAsync();
            return Ok(categoryList.OrderBy(p => p.ID));
        }
    }
}
