using Microsoft.EntityFrameworkCore;
using RedBadgeFinal.Data.Data;
using RedBadgeFinal.Models.Models.BlogModel;
using RedBadgeFinal.Models.Models.EventEntityModel;
using RedBadgeFinal.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Services.BlogServices
{
    public class BlogService : IBlogService
    {
        private readonly ApplicationDbContext _context;

        public BlogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateBlog(BlogCreate model)
        {
            if (model == null) return false;
            var blog = new Blog
            {

                Title = model.Title,
                Description = model.Description,
                UserEntityId = model.UserEntityId,

            };
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<BlogListItem>> GetBlogList()
        {
            var blogs = await _context.Blogs.Select(entity => new BlogListItem
            {
                Id = entity.Id,
                Title = entity.Title,
            })
            .ToListAsync();
            return blogs;
        }
        
        public async Task<bool> UpdateBlog(int id, BlogEdit model)
        {
            if (id != model.Id)
            {
                return false;
            }
            else
            {
                var blogsInDB = await _context.Blogs.FindAsync(model.Id);
                if (blogsInDB != null) return false;

                blogsInDB.Title = model.Title;
                blogsInDB.Description = model.Description;

                await _context.SaveChangesAsync();
                return true;
            }

         
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

        public async Task<BlogDetails> GetBLogDetails(int id)
        {
            var blog = await _context.Blogs.Include(e => e.EventEntities).SingleOrDefaultAsync(x => x.Id == id);
            if (blog is null)
            {
                return null;
            }

            var evententities = await _context.Events.Where(e => e.BlogId == blog.Id).Select(e => new EventListItem
            {
                Id = e.Id,
                Title = e.Title,
            }).ToListAsync();
            if (evententities is null) return null;

            return new BlogDetails
            {
                Id = blog.Id,
                Title = blog.Title,
                Description = blog.Description,
                EventEntities = blog.EventEntities
            };
        }
    }
}
