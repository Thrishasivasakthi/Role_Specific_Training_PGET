using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using DAL.Repository;

namespace ServiceLayer.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class SessionsController : ControllerBase
    {
        private readonly IRepository<SessionInfo> _repo;
        public SessionsController(IRepository<SessionInfo> repo) => _repo = repo;

        [HttpGet]
        public IActionResult GetAll() => Ok(_repo.GetAll());

        [HttpPost]
        public IActionResult Create(SessionInfo session)
        {
            _repo.Add(session);
            return Ok("Session created");
        }

        [HttpPut]
        public IActionResult Update(SessionInfo session)
        {
            _repo.Update(session);
            return Ok("Session updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return Ok("Session deleted");
        }
    }

}
