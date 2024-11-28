using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibrayManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [HttpGet(Name = "GetAllBook")]
        public string Get()
        {
            return "Blabla";
        }
    }
}
