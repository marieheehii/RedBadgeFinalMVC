using Microsoft.EntityFrameworkCore;
using RedBadgeFinal.Data.Data;
using RedBadgeFinal.Models.Models.EventEntity;
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
            var evententity = await _context.Events.FirstOrDefaultAsync(CreateEventEntity => CreateEventEntity.Id == id);
            if(evententity is null)
            {
                return null;
            }
            return new EventDetail
            {
                Title = evententity.Title,
                Description = evententity.Description,
                Likes = evententity.Likes,
                Participants = evententity.Participants,
                BlogId = evententity.BlogId,

            };
        }


        public async Task<IEnumerable<EventListItem>> GetEventEntityList()
        {
            var evententities = await _context.Events.Select(entity => new EventListItem
            {
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
                if (eventsinDB != null) return false;

                eventsinDB.Title = model.Title;
                eventsinDB.Description = model.Description;

                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
