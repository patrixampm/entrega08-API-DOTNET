using Event_APIREST.Interfaces;
using Event_APIREST.Models;
using Event_APIREST.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Event_APIREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantRepository _participantRepository;
        public ParticipantController(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }
        [HttpGet]
        public ActionResult<List<Participant>> Get()
        {
            return _participantRepository.GetParticipants();
        }

        [HttpGet("{id}")]
        public ActionResult<Participant> GetParticipant(int id)
        {
            var newParticipant = _participantRepository.GetParticipantById(id);

            if (newParticipant == null)
            {
                return new NotFoundResult();
            }

            return newParticipant;
        }

        [HttpPost]
        public ActionResult CreateParticipant(Participant newParticipant)
        {
            try
            {
                _participantRepository.AddParticipant(newParticipant);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult UpdateParticipant(Participant Participant)
        {
            try
            {
                _participantRepository.UpdateParticipant(Participant);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteParticipant(int id)
        {
            try
            {
                _participantRepository.DeleteParticipant(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
