using LibrayManagementApi.Common.Model;
using LibrayManagementApi.DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace LibrayManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IGenericRepository<BOOK> _bookService;
        public BookController(IGenericRepository<BOOK> bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("GetAllBook")]
        public async Task<IActionResult> GetAllCompanies()
        {
            var bookList = await _bookService.GetAllAsync();
            return Ok(bookList.OrderBy(p => p.ID));
        }
        [HttpGet("GetBookById")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            return Ok(book);
        }
    }
}