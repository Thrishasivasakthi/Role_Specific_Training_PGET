using AppUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace AppUI.Controllers
{
    [Route("ParticipantDetails")]
    public class ParticipantDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ParticipantDetailController(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        [NonAction]
        public HttpClient GetClient()
        {
            var client = _httpClientFactory.CreateClient("EventDb_API");
            var token = HttpContext.Session.GetString("jwttoken");
            if (!string.IsNullOrEmpty(token))
            {
                token = token.Trim('"');
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return client;
        }

        [Route("ParticipantList", Name = "ParticipantList")]
        public async Task<IActionResult> GetAllParticipants()
        {
            var client = GetClient();
            var list = await client.GetFromJsonAsync<List<ParticipantEventDetails>>("api/v1/Participant");
            return View(list);
        }

        [HttpGet]
        [Route("AddParticipant", Name = "AddParticipant")]
        public IActionResult AddParticipant()
        {
            return View();
        }

        [HttpPost]
        [Route("SaveParticipant")]
        public async Task<IActionResult> AddParticipant(ParticipantEventDetails participant)
        {
            var client = GetClient();
            var response = await client.PostAsJsonAsync("api/v1/Participant", participant);
            if (response.IsSuccessStatusCode)
                return RedirectToRoute("ParticipantList");
            return View(participant);
        }

        [Route("UpdateParticipant/{id}", Name = "UpdateParticipant")]
        public async Task<IActionResult> UpdateParticipant(int id)
        {
            var client = GetClient();
            var data = await client.GetFromJsonAsync<ParticipantEventDetails>($"api/v1/Participant/{id}");
            return View(data);
        }

        [HttpPost]
        [Route("EditParticipant", Name = "EditParticipant")]
        public async Task<IActionResult> UpdateParticipant(ParticipantEventDetails participant)
        {
            var client = GetClient();
            var response = await client.PutAsJsonAsync($"api/v1/Participant/{participant.Id}", participant);
            if (response.IsSuccessStatusCode)
                return RedirectToRoute("ParticipantList");
            return View(participant);
        }

        [Route("DeleteParticipant/{id}", Name = "DeleteParticipant")]
        public async Task<IActionResult> DeleteParticipant(int id)
        {
            var client = GetClient();
            var data = await client.GetFromJsonAsync<ParticipantEventDetails>($"api/v1/Participant/{id}");
            return View(data);
        }

        [HttpPost]
        [Route("RemoveParticipant", Name = "RemoveParticipant")]
        public async Task<IActionResult> DeleteParticipant(ParticipantEventDetails participant)
        {
            var client = GetClient();
            var response = await client.DeleteAsync($"api/v1/Participant/{participant.Id}");
            if (response.IsSuccessStatusCode)
                return RedirectToRoute("ParticipantList");
            return View();
        }

        [Route("GetById/{id}", Name = "GetParticipantById")]
        public async Task<IActionResult> GetParticipantById(int id)
        {
            var client = GetClient();
            var p = await client.GetFromJsonAsync<ParticipantEventDetails>($"api/v1/Participant/{id}");
            return View(p);
        }
    }
}
