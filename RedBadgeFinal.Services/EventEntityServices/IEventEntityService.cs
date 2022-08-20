using RedBadgeFinal.Models.Models.EventEntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Services.EventEntityServices
{
    public interface IEventEntityService
    {
        Task<bool> CreateEventEntity(EventCreate model);
        Task<IEnumerable<EventListItem>> GetEventEntityList();
        Task<EventDetail> GetEventEntityDetails(int id);
        Task<bool> UpdateEventEntity(int id, EventEdit model);
        Task<bool> DeleteEventEntity(int id);
    }
}

