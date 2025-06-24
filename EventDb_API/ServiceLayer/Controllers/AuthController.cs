using DAL.Models;
using DAL.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTO;
using ServiceLayer.Services;

namespace ServiceLayer.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthController : ControllerBase
    {
        private readonly IRepository<UserInfo> _userRepo;
        private readonly JwtService _jwtService;

        public AuthController(IRepository<UserInfo> userRepo, JwtService jwtService)
        {
            _userRepo = userRepo;
            _jwtService = jwtService;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginDto login)
        {
            var user = _userRepo.GetAll()
                .FirstOrDefault(u => u.EmailId == login.EmailId && u.Password == login.Password);

            if (user == null)
                return Unauthorized("Invalid email or password");

            var token = _jwtService.GenerateToken(user.EmailId, user.Role);

            return Ok(new
            {
                Token = token,
                Role = user.Role,
                EmailId = user.EmailId,
                UserName = user.UserName
            });
        }
    }
}
