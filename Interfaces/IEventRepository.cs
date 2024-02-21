using Event_APIREST.Models;

namespace Event_APIREST.Interfaces
{
    public interface IEventRepository
    {
        List<Event> GetEvents();
        Event GetEventById(int id);
        void AddEvent(Event newEvent);
        void UpdateEvent(Event newEvent);
        void DeleteEvent(int id);
    }
}
