using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using RedBadgeFinal.Data.Data;
using RedBadgeFinal.Models.Models.EventEntityModel;
using RedBadgeFinal.Models.Models.ParticipantsModel;
using RedBadgeFinal.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Services.EventEntityServices
{
    public class EventEntityService : IEventEntityService
    {
        private readonly ApplicationDbContext _context;
        
        public EventEntityService(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public async Task<bool> CreateEventEntity(EventCreate model)
        {
            

            var evententity = new EventEntity
            {
                Title = model.Title,
                Description = model.Description,
                Image = model.Image,
                Location = model.Location,
                BlogId = model.BlogId,
            };
            _context.Events.Add(evententity);
            var numberofchanges = await _context.SaveChangesAsync();
            return numberofchanges == 1;
        }

        public async Task<bool> DeleteEventEntity(int id)
        {
            var evententity = await _context.Events.FindAsync(id);
            if(evententity != null)
            {
                _context.Events.Remove(evententity);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<EventDetail> GetEventEntityDetails(int id)
        {

            var evententity = await _context.Events.Include(e => e.Participants).SingleOrDefaultAsync(x => x.Id == id);
            if (evententity is null)
            {
                return null;
            }
            var participants = await _context.Participants.Where(e => e.EventEntityId == evententity.Id).Select(e => new ListParticipants
            {
                Id = e.Id,
                FirstName = e.FirstName,
            }
            ).ToListAsync();
            if (participants is null) return null;
            return new EventDetail
            {
                Id = evententity.Id,
                Title = evententity.Title,
                Description = evententity.Description,
                Image = evententity.Image,
                Location = evententity.Location,
                Participants = evententity.Participants,
                BlogId = evententity.BlogId,

            };
        }


        public async Task<IEnumerable<EventListItem>> GetEventEntityList()
        {
            var evententities = await _context.Events.Select(entity => new EventListItem
            {
                Id = entity.Id,
                Title = entity.Title,

            })
                .ToListAsync();
                return evententities;
        }

        public async Task<bool> UpdateEventEntity(int id, EventEdit model)
        {
            if (id != model.Id)
            {
                return false;
            }
            else
            {
                var eventsinDB = await _context.Events.FindAsync(model.Id);
                if (eventsinDB == null) return false;

                eventsinDB.Title = model.Title;
                eventsinDB.Description = model.Description;
                eventsinDB.Image = model.Image;


                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
