using Event_APIREST.Models;

namespace Event_APIREST.Interfaces
{
    public interface IParticipantRepository
    {
        List<Participant> GetParticipants();
        Participant GetParticipantById(int id);
        void AddParticipant(Participant newParticipant);
        void UpdateParticipant(Participant Participant);
        void DeleteParticipant(int id);
    }
}
