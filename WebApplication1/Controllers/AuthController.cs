using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly AuthService _service;
        private readonly IConfiguration _config;
        public AuthController(AuthService service, IConfiguration config)
        {
            _service = service;
            _config = config;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthLoginDTO authLoginDTO)
        {
            try
            {
                var user = _service.Login(authLoginDTO);
                Console.WriteLine(user);
                var token = _service.GenerateToken(user, _config);
                Console.WriteLine(token);
                return Ok(new
                {
                    accessToken = token,
                });
            }
            catch (ArgumentException)
            {
                return BadRequest("Incorrect Credentials");
            }
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] AuthRegisterDTO authRegisterDTO)
        {
            try
            {
                User user = _service.Register(authRegisterDTO);
                return Ok(new { user.Id });
            }
            catch (ArgumentException)
            {
                return BadRequest("Username Already Exists");
            }
        }

        [HttpGet("all")]
        public List<User> GetAll()
        {
            return _service.GetAll();
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
