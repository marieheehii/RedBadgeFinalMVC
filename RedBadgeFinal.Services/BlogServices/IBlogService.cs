using RedBadgeFinal.Models.Models.BlogModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedBadgeFinal.Services.BlogServices
{
    public interface IBlogService
    {
        Task<bool> CreateBlog(BlogCreate model);
        Task<IEnumerable<BlogListItem>> GetBlogList();
        Task<BlogDetails> GetBLogDetails(int id);
        Task<bool> UpdateBlog(int id, BlogEdit model);
        Task<bool> DeleteBlog(int id);
    }
}
