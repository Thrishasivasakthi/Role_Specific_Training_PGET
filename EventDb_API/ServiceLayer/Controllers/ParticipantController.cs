using DAL.Models;
using DAL.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ServiceLayer.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ParticipantsController : ControllerBase
    {
        private readonly IRepository<ParticipantEventDetails> _repo;
        public ParticipantsController(IRepository<ParticipantEventDetails> repo) => _repo = repo;

        [HttpGet]
        public IActionResult GetAll() => Ok(_repo.GetAll());

        [Authorize]
        [HttpPost]
        public IActionResult Register(ParticipantEventDetails participant)
        {
            _repo.Add(participant);
            return Ok("Participant registered");
        }
    }

}
