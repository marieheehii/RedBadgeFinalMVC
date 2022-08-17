//using RedBadgeFinal.Data.Data;
//using RedBadgeFinal.Models.Models.EventEntity;
//using RedBadgeFinal.MVC.Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace RedBadgeFinal.Services.EventEntityServices
//{
//    public class EventEntityService : IEventEntityService
//    {
//        private readonly ApplicationDbContext _context;

//        public EventEntityService (ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<bool> CreateEvent(EventCreate model)
//        {
//            var evententity = new EventEntity
//            {
              
//                Prop = model.Prop

//            };
//            _context.Events.Add(evententity);
//            var numberOfChanges = await _context.SaveChangesAsync();
//            return numberOfChanges == 1;
//        }

//        public async Task<IEnumerable<EventListItem>> GetListEvents()
//        {
//            var eventenity = await _context.Events.Select(entity => new EventListItem
//            {
//                prop = entity.props
//            })
//            .ToListAsync();
//            return eventenity;
//        }
//        public async Task<EventDetail> GetEventDetails(int id)
//        {
//            var evententity = await _context.Events.FirstOrDefaultAsync(entity => entity.ID == id);
//            if (evententity is null)
//            {
//                return null;
//            }
//            return new EventDetail
//            {
//                prop = evententity.prop,
//            };
//        }
//        public async Task<bool> UpdateEventEnity(int id,  EventEdit model)
//        {
//            var evententity = await _context.Events.FindAsync(id);
//            if (evententity == null) return false;

//            something.prop = model.prop;

//            await _context.SaveChangesAsync();
//            return true;
//        }
//        public async Task<bool> DeleteEventEnity(int id)
//        {
//            var evententity = await _context.Events.FindAsync(id);
//            if (evententity != null)
//            {
//                _context.Events.Remove(evententity);
//                await _context.SaveChangesAsync();
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }
//    }
//}
