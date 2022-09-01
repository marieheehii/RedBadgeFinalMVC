using Microsoft.EntityFrameworkCore;
using RedBadgeFinal.Data.Data;
using RedBadgeFinal.Models.Models.ParticipantsModel;
using RedBadgeFinal.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Services.ParticipantServices
{
    public class ParticipantService : IParticipationService
    {
        private readonly ApplicationDbContext _context;
        public ParticipantService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateParticipant(CreateParticipant model)
        {
            var participant = new Participants
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                email = model.email,
                EventEntityId = model.EventEntityId,
            };
            _context.Participants.Add(participant);
            var numberofchanges = await _context.SaveChangesAsync();
            return numberofchanges == 1;
            
        }

        public async Task<bool> DeleteParticipant(int id)
        {
            var participant = await _context.Participants.FindAsync(id);
            if(participant != null)
            {
                _context.Participants.Remove(participant);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public async Task<DetailParticipant> GetParticipantDetail(int id)
        {
            var participant = await _context.Participants.FirstOrDefaultAsync(CreateParticipant => CreateParticipant.Id == id);
            if (participant is null) return null;

            return new DetailParticipant
            {
                Id = participant.Id,
                FirstName = participant.FirstName,
                LastName = participant.LastName,
            };
        }

        public async Task<IEnumerable<ListParticipants>> GetParticipantList()
        {
            var participants = await _context.Participants.Select(entity => new ListParticipants
            {
                Id = entity.Id,
                FirstName = entity.FirstName
            }).ToListAsync();
            return participants;
        }

        public async Task<bool> UpdateParticipant(int id, EditParticipant model)
        {
            if (id != model.Id)
            {
                return false;
            }
            else
            {
                var eventsinDB = await _context.Participants.FindAsync(model.Id);
                if (eventsinDB != null) return false;

                eventsinDB.FirstName = model.FirstName;
                eventsinDB.LastName = model.LastName;
                eventsinDB.email = model.email;

                await _context.SaveChangesAsync();
                return true;
            }
            
        }
    }
}
