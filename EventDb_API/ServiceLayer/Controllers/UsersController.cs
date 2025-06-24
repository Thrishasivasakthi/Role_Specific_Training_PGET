using DAL.Models;
using DAL.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<UserInfo> _repo;

        public UsersController(IRepository<UserInfo> repo)
        {
            _repo = repo;
        }

      
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(UserInfo user)
        {
            _repo.Add(user);
            return Ok("User created");
        }

      
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAll());
        }
    }
}
