using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConsumerApi.Controllers
{
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        [Authorize]
        [HttpGet("getdata")]
        public IActionResult GetData()
        {
            var user = HttpContext.User;
            return Ok("Some data!");
        }
    }
}
