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

        public EventEntityService (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateEvent(EventCreate model)
        {
            var evententity = new EventEntity
            {
              
                BlogProp = model.BLogProp

            };
            _context.Blogs.Add(blog);
            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        public async Task<IEnumerable<BlogListItem>> GetBlogList()
        {
            var blogs = await _context.Blogs.Select(entity => new BlogListItem
            {
                blogprop = entity.blogprop
            })
            .ToListAsync();
            return blogs;
        }
        public async Task<BlogDetails> GetBlogDetails(int id)
        {
            var blog = await _context.Blogs.FirstOrDefaultAsync(entity => entity.ID == id);
            if (blog is null)
            {
                return null;
            }
            return new BlogDetails
            {
                prop = blog.prop,
            };
        }
        public async Task<bool> UpdateBlog(int id,  BlogEdit model)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null) return false;

            blog.prop = model.prop;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteBlog(int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog != null)
            {
                _context.Blogs.Remove(blog);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
