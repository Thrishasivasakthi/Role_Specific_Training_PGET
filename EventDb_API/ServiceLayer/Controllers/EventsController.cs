using DAL.Models;
using DAL.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class EventsController : ControllerBase
    {
        private readonly IRepository<EventDetails> _repo;
        public EventsController(IRepository<EventDetails> repo) => _repo = repo;

        [HttpGet]
        public IActionResult GetAll() => Ok(_repo.GetAll());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ev = _repo.Get(id);
            return ev == null ? NotFound() : Ok(ev);
        }
            
        [Authorize]
        [HttpPost]
        public IActionResult Create(EventDetails ev)
        {
            _repo.Add(ev);
            return Ok("Event created");
        }

        [Authorize]
        [HttpPut]
        public IActionResult Update(EventDetails ev)
        {
            _repo.Update(ev);
            return Ok("Event updated");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repo.Delete(id);
            return Ok("Event deleted");
        }
    }

}
