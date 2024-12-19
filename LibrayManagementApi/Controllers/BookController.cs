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
        private readonly IGenericRepository<VW_BOOK> _vwBookService;

        public BookController(IGenericRepository<BOOK> bookService, IGenericRepository<VW_BOOK> vwBookService)
        {
            _bookService = bookService;
            _vwBookService = vwBookService;
        }
        [HttpGet("GetAllBook")]
        public async Task<IActionResult> GetAllCompanies()
        {
            var bookList = await _bookService.GetAllAsync();

            return Ok(bookList.OrderBy(p => p.ID));
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            return Ok(book);
        }
        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetBookByName(string name)
        {
            var book = await _bookService.GetWhere(p => p.NAME == name);
            return Ok(book);
        }

        [HttpGet("GetAllBookWithAliasName")]
        public async Task<IActionResult> GetAllBookWithAliasName()
        {
            var bookList = await _vwBookService.GetAllAsync();

            return Ok(bookList);
        }
        [HttpGet("GetByPublisherName/{publisherName}")]
        public async Task<IActionResult> GetBookByPublisher(string publisherName)
        {
            var book = await _vwBookService.GetWhere(p => p.PUBLISHERNAME == publisherName);
            return Ok(book);
        }

        [HttpGet("GetByPublisherId/{publisherId}")]
        public async Task<IActionResult> GetBookByPublisherId(int publisherId)
        {
            var book = await _bookService.GetWhere(p => p.PUBLISHERID == publisherId);
            return Ok(book);
        }
        [HttpGet("GetBookByCategory/{category}")]
        public async Task<IActionResult> GetBookByCategory(string category)
        {
            var book = await _vwBookService.GetWhere(p => p.CATEGORYNAME.Contains(category));
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> InsertBook(BOOK book)
        {
            var status = await _bookService.InsertAsync(book);

            return Ok(status);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var status = await _bookService.DeleteAsync(id);

            return Ok(status);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBook(BOOK book)
        {
            var status = await _bookService.UpdateAsync(book);

            return Ok(status);
        }
    }
}