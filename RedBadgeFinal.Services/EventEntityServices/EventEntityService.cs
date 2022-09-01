using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using RedBadgeFinal.Data.Data;
using RedBadgeFinal.Models.Models.EventEntityModel;
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
        private readonly IWebHostEnvironment WebHostEnvironment;

        public EventEntityService(ApplicationDbContext context, IWebHostEnvironment webHostEnviornment)
        {
            _context = context;
            webHostEnviornment = WebHostEnvironment;

        }
        public async Task<bool> CreateEventEntity(EventCreate model)
        {
            string stringFileName = UploadImage(model);

            var evententity = new EventEntity
            {
                Title = model.Title,
                Description = model.Description,
                Image = stringFileName,
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
            string stringFileName = UploadImage();
            var evententity = await _context.Events.FirstOrDefaultAsync(CreateEventEntity => CreateEventEntity.Id == id);
            if(evententity is null)
            {
                return null;
            }
            return new EventDetail
            {
                Title = evententity.Title,
                Description = evententity.Description,
                Image = stringFileName,
                Likes = evententity.Likes,
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
                if (eventsinDB != null) return false;

                eventsinDB.Title = model.Title;
                eventsinDB.Description = model.Description;
                eventsinDB.Image = model.Image;


                await _context.SaveChangesAsync();
                return true;
            }
        }

        public string UploadImage(EventCreate model)
        {
            string fileName = null;
            if (model.Image!=null)
            {
                string uploadDir = Path.Combine(WebHostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "-" + model.Image.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fileStream);
                }
            }
            return fileName;
        }
    }
}
