using Event_APIREST.Context;
using Event_APIREST.Interfaces;
using Event_APIREST.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Event_APIREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventRepository _eventRepository;
        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        
        [HttpGet]
        public ActionResult<List<Event>> Get()
        {
            return _eventRepository.GetEvents();
        }

        [HttpGet("{id}")]
        public ActionResult<Event> GetEvent(int id)
        {
            var newEvent = _eventRepository.GetEventById(id);

            if (newEvent == null)
            {
                return new NotFoundResult();
            }

            return newEvent;
        }

        [HttpPost]
        public ActionResult CreateEvent(Event newEvent)
        {
            try
            {
                _eventRepository.AddEvent(newEvent);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult UpdateEvent(Event newEvent)
        {
            try
            {
                _eventRepository.UpdateEvent(newEvent);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEvent(int id)
        {
            try
            {
                _eventRepository.DeleteEvent(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
