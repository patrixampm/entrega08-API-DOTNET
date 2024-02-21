using Event_APIREST.Context;
using Event_APIREST.Interfaces;
using Event_APIREST.Models;
using System.Text.Json;

namespace Event_APIREST.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly AplicationDbContext _context;

        public EventRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public void AddEvent(Event newEvent)
        {
            var existingEvent = _context.Events.FirstOrDefault(e => e.Id == newEvent.Id);
            if (existingEvent != null)
            {
                throw new Exception("Ya existe un evento con ese id");
            }

            _context.Events.Add(newEvent);
            _context.SaveChanges();
        }

        public void DeleteEvent(int id)
        {
            var eventToDelete = _context.Events.FirstOrDefault(e => e.Id == id);

            if (eventToDelete == null)
            {
                throw new Exception("Evento no encontrado");
            }
            _context.Events.Remove(eventToDelete);
            _context.SaveChanges();
        }

        public Event GetEventById(int id)
        {
            try
            {
                var foundEvent = _context.Events.FirstOrDefault(e => e.Id == id);
                return foundEvent;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Event> GetEvents()
        {
            try
            {
                var events = _context.Events.ToList();
                return events;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateEvent(Event newEvent)
        {
            var existingEvent = _context.Events.FirstOrDefault(e => e.Id == newEvent.Id);
            if (existingEvent == null)
            {
                throw new Exception("Evento no encontrado");
            }

            existingEvent.Name = newEvent.Name;
            existingEvent.StartDate = newEvent.StartDate;
            existingEvent.Description = newEvent.Description;
            _context.SaveChanges();

        }
    }
}
