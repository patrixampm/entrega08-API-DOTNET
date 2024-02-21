using Event_APIREST.Context;
using Event_APIREST.Interfaces;
using Event_APIREST.Models;
using System.Text.Json;

namespace Event_APIREST.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly AplicationDbContext _context;

        public ParticipantRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public void AddParticipant(Participant newParticipant)
        {
            var existingParticipant = _context.Participants.FirstOrDefault(e => e.Id == newParticipant.Id);
            if (existingParticipant != null)
            {
                throw new Exception("Ya existe un participante con ese id");
            }

            _context.Participants.Add(newParticipant);
            _context.SaveChanges();
        }

        public void DeleteParticipant(int id)
        {
            var participantToDelete = _context.Participants.FirstOrDefault(e => e.Id == id);

            if (participantToDelete == null)
            {
                throw new Exception("Participante no encontrado");
            }
            _context.Participants.Remove(participantToDelete);
            _context.SaveChanges();
        }

        public Participant GetParticipantById(int id)
        {
            try
            {
                var foundParticipant = _context.Participants.FirstOrDefault(e => e.Id == id);
                return foundParticipant;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Participant> GetParticipants()
        {
            try
            {
                var participants = _context.Participants.ToList();
                return participants;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateParticipant(Participant Participant)
        {
            var existingParticipant = _context.Participants.FirstOrDefault(e => e.Id == Participant.Id);
            if (existingParticipant == null)
            {
                throw new Exception("Participante no encontrado");
            }

            existingParticipant.Name = Participant.Name;
            existingParticipant.LastName = Participant.LastName;
            existingParticipant.Email = Participant.Email;
            _context.SaveChanges();
        }
    }
}
