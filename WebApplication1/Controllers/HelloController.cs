using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        [Route("get")]
        public string SayHello()
        {
            return "Hello World!";
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadCV(IFormFile file)
        {
            return BadRequest("No File uploaded");
        }
    }
}
