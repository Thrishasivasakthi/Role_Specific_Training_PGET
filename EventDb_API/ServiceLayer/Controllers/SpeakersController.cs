using DAL.Models;
using DAL.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServiceLayer.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class SpeakersController : ControllerBase
    {
        private readonly IRepository<SpeakerDetails> _repo;
        public SpeakersController(IRepository<SpeakerDetails> repo) => _repo = repo;

        [HttpGet]
        public IActionResult GetAll() => Ok(_repo.GetAll());

        [Authorize]
        [HttpPost]
        public IActionResult Create(SpeakerDetails speaker)
        {
            _repo.Add(speaker);
            return Ok("Speaker created");
        }
    }

}
